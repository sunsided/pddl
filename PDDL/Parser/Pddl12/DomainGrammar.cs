using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
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
        public static readonly Parser<IEnumerable<IAtomicFormulaSkeleton>> PredicatesDefinition
            = CreatePredicatesDefinition();

        /// <summary>
        /// The extension definition
        /// </summary>
        [NotNull]
        public static readonly Parser<IEnumerable<IName>> ExtensionDefinition
            = CreateExtensionDefinition();

        /// <summary>
        /// The requirements definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IEnumerable<IRequirement>> RequirementsDefinition
            = CreateRequirementsDefinition();

        /// <summary>
        /// The types definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IEnumerable<IType>> TypesDefinition
            = CreateTypesDefinition();

        /// <summary>
        /// The constants definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IEnumerable<IConstant>> ConstantsDefinition
            = CreateConstantsDefinition();

        /// <summary>
        /// The timeless definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IEnumerable<ILiteral<IName>>> TimelessDefinition
            = CreateTimelessDefinition();

        /// <summary>
        /// The domain definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IDomain> DomainDefinition
            = CreateDomainDefinition();
        
        #region Factory Functions
        
        /// <summary>
        /// Creates a parser for the domain structure.
        /// </summary>
        /// <returns>Parser&lt;Pddl12DomainStructure&gt;.</returns>
        [NotNull]
        private static Parser<DomainStructure> CreateDomainStructure()
        {
            return (
                from matches in ActionGrammar.ActionDefinition.Or<IDomainStructureElement>(AxiomGrammar.AxiomDefinition).Many()
                select DomainStructure.FromSequence(matches)
                );
        }

        /// <summary>
        /// Creates the domain definition.
        /// </summary>
        /// <returns>Parser&lt;Domain&gt;.</returns>
        [NotNull]
        private static Parser<Domain> CreateDomainDefinition()
        {
            var ds = CreateDomainStructure();

            return (
                from open in CommonGrammar.OpeningParenthesis
                from domainKeyword in Keywords.Domain
                from domainName in CommonGrammar.NameNonToken.Token()
                from close in CommonGrammar.ClosingParenthesis
                from extensions in ExtensionDefinition.Optional()
                from requirements in RequirementsDefinition.Optional()
                from types in TypesDefinition.Optional()
                from constants in ConstantsDefinition.Optional()
                from predicates in PredicatesDefinition.Optional()
                from timeless in TimelessDefinition.Optional()
                // structure-def following
                from structure in ds // TODO: this should go for the whole domain structure

                // bundle and go
                let ex = CommonGrammar.Wrap(extensions)
                let dr = CommonGrammar.Wrap(requirements)
                let ty = CommonGrammar.Wrap(types)
                let co = CommonGrammar.Wrap(constants)
                let pr = CommonGrammar.Wrap(predicates)
                let tl = CommonGrammar.Wrap(timeless)
                select new Domain(domainName, dr, ty, co, pr, tl)
                {
                    Actions = structure.Actions,
                    Axioms = structure.Axioms
                }
                );
        }

        /// <summary>
        /// Creates the timeless definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;ILiteral&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<ILiteral<IName>>> CreateTimelessDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Timeless
                from literals in CommonGrammar.LiteralOfName.Many()
                from close in CommonGrammar.ClosingParenthesis
                select literals
                ).Token();
        }

        /// <summary>
        /// Creates the constants definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IConstant&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IConstant>> CreateConstantsDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Constants
                from types in TypedLists.TypedListOfConstant
                from close in CommonGrammar.ClosingParenthesis
                select types
                ).Token();
        }

        /// <summary>
        /// Creates the types definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IType&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IType>> CreateTypesDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Types
                from types in TypedLists.TypedListOfType
                from close in CommonGrammar.ClosingParenthesis
                select types
                ).Token();
        }

        /// <summary>
        /// Creates the requirements definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IRequirement&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IRequirement>> CreateRequirementsDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Requirements
                from keys in ValidRequirements.Many()
                from close in CommonGrammar.ClosingParenthesis
                select keys
                ).Token();
        }

        /// <summary>
        /// Creates the extension definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IName&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IName>> CreateExtensionDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Extends
                from names in CommonGrammar.NameNonToken.Token().AtLeastOnce()
                from close in CommonGrammar.ClosingParenthesis
                select names
                ).Token();
        }

        /// <summary>
        /// Creates the predicates definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IAtomicFormulaSkeleton&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IAtomicFormulaSkeleton>> CreatePredicatesDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Predicates
                from skeletons in CommonGrammar.AtomicFormulaSkeleton.AtLeastOnce()
                from close in CommonGrammar.ClosingParenthesis
                select skeletons
                ).Token();
        }

        #endregion
    }
}
