using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PDDL.Model.PDDL12;
using PDDL.Model.PDDL12.DomainElements;
using PDDL.Model.PDDL12.ProblemElements;
using Sprache;

namespace PDDL.Parser.PDDL12
{
    /// <summary>
    /// Class ProblemGrammar.
    /// </summary>
    internal static class ProblemGrammar
    {
        /// <summary>
        /// The requirements definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IProblemRequireDefinition> RequirementsDefinition
            = CreateRequirementsDefinition();

        /// <summary>
        /// The initial state definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IProblemInitialStateDefinition> InitDefinition =
            CreateInitDefinition();

        /// <summary>
        /// The objects definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IProblemObjectsDefinition> ObjectsDefinition =
            CreateObjectDefinition();

        /// <summary>
        /// The goal definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IProblemGoalDefinition> GoalDefinition =
            CreateGoalDefinition();

        /// <summary>
        /// The problem definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IProblem> ProblemDefinition
            = CreateProblemDefinition();
        

        #region Factory Functions

        /// <summary>
        /// Creates the domain definition element parser.
        /// </summary>
        /// <returns>Parser&lt;IReadOnlyList&lt;IDomainDefinitionElement&gt;&gt;.</returns>
        private static Parser<IReadOnlyList<IProblemDefinitionElement>> CreateProblemDefinitionElementParser()
        {
            return (
                from matches in
                    RequirementsDefinition
                    .Or<IProblemDefinitionElement>(InitDefinition)
                    .Or<IProblemDefinitionElement>(ObjectsDefinition)
                    .Or<IProblemDefinitionElement>(GoalDefinition)
                    .Many()
                select matches.ToList()
                );
        }

        /// <summary>
        /// Creates the object definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;ILiteral&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IProblemObjectsDefinition> CreateObjectDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CObjects
                from objects in TypedLists.TypedListOfObject
                from close in CommonGrammar.ClosingParenthesis
                select new ProblemObjectsDefinition(objects.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the initial state definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;ILiteral&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IProblemInitialStateDefinition> CreateInitDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CInit
                from literals in CommonGrammar.LiteralOfName.Many()
                from close in CommonGrammar.ClosingParenthesis
                select new ProblemInitialStateDefinition(literals.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the requirements definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IRequirement&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IProblemRequireDefinition> CreateRequirementsDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CRequirements
                from keys in RequirementsGrammar.ValidRequirements.Many()
                from close in CommonGrammar.ClosingParenthesis
                select new RequirementsDefinition(keys.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the goal definition.
        /// </summary>
        /// <returns>Parser&lt;IProblemGoalDefinition&gt;.</returns>
        [NotNull]
        private static Parser<IProblemGoalDefinition> CreateGoalDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CGoal
                from goal in GoalGrammar.GoalDescription
                from close in CommonGrammar.ClosingParenthesis
                select new ProblemGoalDefinition(goal)
                ).Token();
        }

        /// <summary>
        /// Creates the domain definition.
        /// </summary>
        /// <returns>Parser&lt;Domain&gt;.</returns>
        [NotNull]
        private static Parser<IProblem> CreateProblemDefinition()
        {
            var definition = CreateProblemDefinitionElementParser();

            return (
                // header
                from open in CommonGrammar.OpeningParenthesis
                from problemKeyword in Keywords.Problem
                from problemName in CommonGrammar.NameNonToken.Token()
                from close in CommonGrammar.ClosingParenthesis
                
                from dopen in CommonGrammar.OpeningParenthesis
                from domainKeyword in Keywords.CDomain
                from domainName in CommonGrammar.NameNonToken.Token()
                from dclose in CommonGrammar.ClosingParenthesis

                // definition body
                from body in definition

                // bundle and go
                select ProblemFactory.FromSequence(problemName, domainName, body)
                );
        }

        #endregion Factory Functions
    }
}
