using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.DomainElements;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class DomainGrammar.
    /// </summary>
    internal static class DomainGrammar
    {
        /// <summary>
        /// The valid requirements
        /// </summary>
        [NotNull]
        public static Parser<IRequirement> ValidRequirements =
                (from value in
                     Parse.String(":strips")
                     .Or(Parse.String(":typing"))
                     .Or(Parse.String(":disjunctive-preconditions"))
                     .Or(Parse.String(":equality"))
                     .Or(Parse.String(":existential-preconditions"))
                     .Or(Parse.String(":universal-preconditions"))
                     .Or(Parse.String(":quantified-preconditions"))
                     .Or(Parse.String(":conditional-effects"))
                     .Or(Parse.String(":action-expansions"))
                     .Or(Parse.String(":foreach-expansions"))
                     .Or(Parse.String(":dag-expaeinsions"))
                     .Or(Parse.String(":domain-axioms"))

                     .Or(Parse.String(":subgoal-through-axioms"))
                     .Or(Parse.String(":safety-constraints"))
                     .Or(Parse.String(":expression-evaluation"))
                     .Or(Parse.String(":fluents"))
                     .Or(Parse.String(":open-world"))
                     .Or(Parse.String(":true-negation"))
                     .Or(Parse.String(":adl"))
                     .Or(Parse.String(":ucpop"))
                     .Text()
                 select new Requirement(value)
                ).Token();

        /// <summary>
        /// The predicates definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IDomainPredicatesDefinition> PredicatesDefinition
            = CreatePredicatesDefinition();

        /// <summary>
        /// The extension definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IDomainExtensionDefinition> ExtensionDefinition
            = CreateExtensionDefinition();

        /// <summary>
        /// The requirements definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IDomainRequireDefinition> RequirementsDefinition
            = CreateRequirementsDefinition();

        /// <summary>
        /// The types definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IDomainTypesDefinition> TypesDefinition
            = CreateTypesDefinition();

        /// <summary>
        /// The constants definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IDomainConstantsDefinition> ConstantsDefinition
            = CreateConstantsDefinition();

        /// <summary>
        /// The timeless definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IDomainTimelessDefinition> TimelessDefinition
            = CreateTimelessDefinition();

        /// <summary>
        /// The safety definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IDomainSafetyDefinition> SafetyDefinition
            = CreateSafetyDefinition();

        /// <summary>
        /// The vars definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IDomainVarsDefinition> VariablesDefinition
            = CreateVarsDefinition();

        /// <summary>
        /// The domain definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IDomain> DomainDefinition
            = CreateDomainDefinition();
        
        #region Factory Functions
        
        /// <summary>
        /// Creates the domain definition element parser.
        /// </summary>
        /// <returns>Parser&lt;IReadOnlyList&lt;IDomainDefinitionElement&gt;&gt;.</returns>
        private static Parser<IReadOnlyList<IDomainDefinitionElement>> CreateDomainDefinitionElementParser()
        {
            return (
                from matches in 
                    ExtensionDefinition
                    .Or<IDomainDefinitionElement>(RequirementsDefinition)
                    .Or<IDomainDefinitionElement>(TypesDefinition)
                    .Or<IDomainDefinitionElement>(ConstantsDefinition)
                    .Or<IDomainDefinitionElement>(VariablesDefinition)
                    .Or<IDomainDefinitionElement>(PredicatesDefinition)
                    .Or<IDomainDefinitionElement>(TimelessDefinition)
                    .Or<IDomainDefinitionElement>(SafetyDefinition)
                    .Or<IDomainDefinitionElement>(ActionGrammar.ActionDefinition)
                    .Or<IDomainDefinitionElement>(AxiomGrammar.AxiomDefinition)
                    .Many()
                select matches.ToList()
                );
        }

        /// <summary>
        /// Creates the domain definition.
        /// </summary>
        /// <returns>Parser&lt;Domain&gt;.</returns>
        [NotNull]
        private static Parser<IDomain> CreateDomainDefinition()
        {
            var definition = CreateDomainDefinitionElementParser();

            return (
                // header
                from open in CommonGrammar.OpeningParenthesis
                from domainKeyword in Keywords.Domain
                from domainName in CommonGrammar.NameNonToken.Token()
                from close in CommonGrammar.ClosingParenthesis
                // definition body
                from body in definition
                // bundle and go
                select DomainFactory.FromSequence(domainName, body)
                );
        }

        /// <summary>
        /// Creates the timeless definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;ILiteral&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IDomainTimelessDefinition> CreateTimelessDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CTimeless
                from literals in CommonGrammar.LiteralOfName.Many()
                from close in CommonGrammar.ClosingParenthesis
                select new TimelessDefinition(literals.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the safety definition.
        /// </summary>
        [NotNull]
        private static Parser<IDomainSafetyDefinition> CreateSafetyDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CSafety
                from backgroundGoals in GoalGrammar.GoalDescription.Many()
                from close in CommonGrammar.ClosingParenthesis
                select new SafetyDefinition(backgroundGoals.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the vars definition.
        /// </summary>
        [NotNull]
        private static Parser<IDomainVarsDefinition> CreateVarsDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CDomainVariables
                from variables in TypedLists.TypedListOfDomainVariable
                from close in CommonGrammar.ClosingParenthesis
                select new VarsDefinition(variables.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the constants definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IConstant&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IDomainConstantsDefinition> CreateConstantsDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CConstants
                from constants in TypedLists.TypedListOfConstant
                from close in CommonGrammar.ClosingParenthesis
                select new ConstantsDefinition(constants.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the types definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IType&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IDomainTypesDefinition> CreateTypesDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CTypes
                from types in TypedLists.TypedListOfType
                from close in CommonGrammar.ClosingParenthesis
                select new TypesDefinition(types.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the requirements definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IRequirement&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IDomainRequireDefinition> CreateRequirementsDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CRequirements
                from keys in ValidRequirements.Many()
                from close in CommonGrammar.ClosingParenthesis
                select new RequirementsDefinition(keys.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the extension definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IName&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IDomainExtensionDefinition> CreateExtensionDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CExtends
                from names in CommonGrammar.NameNonToken.Token().AtLeastOnce()
                from close in CommonGrammar.ClosingParenthesis
                select new ExtensionDefinition(names.ToList())
                ).Token();
        }

        /// <summary>
        /// Creates the predicates definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IAtomicFormulaSkeleton&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IDomainPredicatesDefinition> CreatePredicatesDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CPredicates
                from skeletons in CommonGrammar.AtomicFormulaSkeleton.AtLeastOnce()
                from close in CommonGrammar.ClosingParenthesis
                select new PredicatesDefinition(skeletons.ToList())
                ).Token();
        }

        #endregion
    }
}
