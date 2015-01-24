﻿using System.Linq;
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
        private static Parser<IDomain> CreateDomainDefinition()
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
                from structure in ds
                // TODO: this should go for the whole domain structure

                // bundle and go
                let ex = extensions.GetDefinition(def => def.Names) 
                let dr = requirements.GetDefinition(def => def.Requirements)
                let ty = types.GetDefinition(def => def.Types)
                let co = constants.GetDefinition(def => def.Constants)
                let pr = predicates.GetDefinition(def => def.Predicates)
                let tl = timeless.GetDefinition(def => def.Timeless)
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
        private static Parser<IDomainTimelessDefinition> CreateTimelessDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Timeless
                from literals in CommonGrammar.LiteralOfName.Many()
                from close in CommonGrammar.ClosingParenthesis
                select new TimelessDefinition(literals.ToList())
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
                from keyword in Keywords.Constants
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
                from keyword in Keywords.Types
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
                from keyword in Keywords.Requirements
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
                from keyword in Keywords.Extends
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
                from keyword in Keywords.Predicates
                from skeletons in CommonGrammar.AtomicFormulaSkeleton.AtLeastOnce()
                from close in CommonGrammar.ClosingParenthesis
                select new PredicatesDefinition(skeletons.ToList())
                ).Token();
        }

        #endregion
    }
}
