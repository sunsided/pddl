using System.Collections.Generic;
using System.Linq;
using PDDL.Model.Pddl12;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class Pddl12Grammar. This class cannot be inherited.
    /// </summary>
    sealed class Gammar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Gammar"/> class.
        /// </summary>
        public Gammar()
        {
            // TODO: implement domain-vars-def 
            // TODO add :disjunctive-preconditions goals
            // TODO add :existential-preconditions goals
            // TODO add :universal-preconditions goals
            // TODO: add :domain-axioms
            // TODO: add :action-expansions

            PredicatesDefinition = CreatePredicatesDefinition();
            ExtensionDefinition = CreateExtensionDefinition();
            RequirementsDefinition = CreateRequirementsDefinition();
            TypesDefinition = CreateTypesDefinition();
            ConstantsDefinition = CreateConstantsDefinition();

            TimelessDefinition = CreateTimelessDefinition();
            Vars = CreateVars();

            AxiomDefinition = CreateAxiomDefinition();

            DomainDefinition = CreateDomainDefinition();
            DefineDefinition = CreateDefineDefinition();
        }

        /// <summary>
        /// Gets or sets the axioms.
        /// </summary>
        /// <value>The axioms.</value>
        internal Parser<IAxiom> AxiomDefinition { get; set; }

        /// <summary>
        /// The valid requirements
        /// </summary>
        internal readonly static Parser<IRequirement> ValidRequirements =
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
        internal readonly Parser<IEnumerable<IAtomicFormulaSkeleton>> PredicatesDefinition;

        /// <summary>
        /// The extension definition
        /// </summary>
        internal readonly Parser<IEnumerable<IName>> ExtensionDefinition;

        /// <summary>
        /// The requirements definition
        /// </summary>
        internal readonly Parser<IEnumerable<IRequirement>> RequirementsDefinition;
        
        /// <summary>
        /// The types definition
        /// </summary>
        internal readonly Parser<IEnumerable<IType>> TypesDefinition;
        
        /// <summary>
        /// The constants definition
        /// </summary>
        internal readonly Parser<IEnumerable<IConstant>> ConstantsDefinition;
        
        /// <summary>
        /// The timeless definition
        /// </summary>
        internal readonly Parser<IEnumerable<ILiteral<IName>>> TimelessDefinition;
        
        /// <summary>
        /// The domain definition
        /// </summary>
        internal readonly Parser<IDomain> DomainDefinition;
        
        /// <summary>
        /// The define definition
        /// </summary>
        internal readonly Parser<IDomain> DefineDefinition;

        /// <summary>
        /// Creates the define definition.
        /// </summary>
        /// <returns>Parser&lt;IDomain&gt;.</returns>
        private Parser<IDomain> CreateDefineDefinition()
        {
            return (
                from openDefine in OpeningParenthesis
                from defineKeyword in Parse.String("define").Token()
                from domain in DomainDefinition
                from closeDefine in ClosingParenthesis
                select domain
                );
        }

        /// <summary>
        /// Creates a parser for the domain structure.
        /// </summary>
        /// <returns>Parser&lt;Pddl12DomainStructure&gt;.</returns>
        private Parser<DomainStructure> CreateDomainStructure()
        {
            return (
                from matches in ActionDefinition.Or<IDomainStructureElement>(AxiomDefinition).Many()
                select DomainStructure.FromSequence(matches)
                );
        }

        /// <summary>
        /// Creates the domain definition.
        /// </summary>
        /// <returns>Parser&lt;Domain&gt;.</returns>
        private Parser<Domain> CreateDomainDefinition()
        {
            var ds = CreateDomainStructure();

            return (
                from open in OpeningParenthesis
                from domainKeyword in Parse.String("domain").Token()
                from domainName in NameNonToken.Token()
                from close in ClosingParenthesis
                from extensions in ExtensionDefinition.Optional()
                from requirements in RequirementsDefinition.Optional()
                from types in TypesDefinition.Optional()
                from constants in ConstantsDefinition.Optional()
                from predicates in PredicatesDefinition.Optional()
                from timeless in TimelessDefinition.Optional()
                // structure-def following
                from structure in ds // TODO: this should go for the whole domain structure

                // bundle and go
                let ex = Wrap(extensions)
                let dr = Wrap(requirements)
                let ty = Wrap(types)
                let co = Wrap(constants)
                let pr = Wrap(predicates)
                let tl = Wrap(timeless)
                select new Domain(domainName, dr, ty, co, pr, tl)
                       {
                           Actions = structure.Actions,
                           Axioms = structure.Axioms
                       }
                );
        }

        /// <summary>
        /// The vars
        /// </summary>
        internal readonly Parser<IEnumerable<IVariableDefinition>> Vars;

        /// <summary>
        /// Creates the vars.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IVariableDefinition&gt;&gt;.</returns>
        private Parser<IEnumerable<IVariableDefinition>> CreateVars()
        {
            return (
                from keyword in Parse.String(":vars").Token()
                from open in OpeningParenthesis
                from variables in TypedListOfVariable.Token()
                from close in ClosingParenthesis
                select variables
                ).Token();
        }
        
        /// <summary>
        /// Creates the timeless definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;ILiteral&gt;&gt;.</returns>
        private Parser<IEnumerable<ILiteral<IName>>> CreateTimelessDefinition()
        {
            return (
                from open in OpeningParenthesis
                from keyword in Parse.String(":timeless").Token()
                from literals in LiteralOfName.Many()
                from close in ClosingParenthesis
                select literals
                ).Token();
        }
        
        /// <summary>
        /// Creates the constants definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IConstant&gt;&gt;.</returns>
        private Parser<IEnumerable<IConstant>> CreateConstantsDefinition()
        {
            return (
                from open in OpeningParenthesis
                from keyword in Parse.String(":constants").Token()
                from types in TypedListOfConstant
                from close in ClosingParenthesis
                select types
                ).Token();
        }
        
        /// <summary>
        /// Creates the types definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IType&gt;&gt;.</returns>
        private Parser<IEnumerable<IType>> CreateTypesDefinition()
        {
            return (
                from open in OpeningParenthesis
                from keyword in Parse.String(":types").Token()
                from types in TypedListOfType
                from close in ClosingParenthesis
                select types
                ).Token();
        }
        
        /// <summary>
        /// Creates the requirements definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IRequirement&gt;&gt;.</returns>
        private static Parser<IEnumerable<IRequirement>> CreateRequirementsDefinition()
        {
            return (
                from open in OpeningParenthesis
                from keyword in Parse.String(":requirements").Token()
                from keys in ValidRequirements.Many()
                from close in ClosingParenthesis
                select keys
                ).Token();
        }

        /// <summary>
        /// Creates the extension definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IName&gt;&gt;.</returns>
        private static Parser<IEnumerable<IName>> CreateExtensionDefinition()
        {
            return (
                from open in OpeningParenthesis
                from keyword in Parse.String(":extends").Token()
                from names in NameNonToken.Token().AtLeastOnce()
                from close in ClosingParenthesis
                select names
                ).Token();
        }

        /// <summary>
        /// Creates the predicates definition.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IAtomicFormulaSkeleton&gt;&gt;.</returns>
        private Parser<IEnumerable<IAtomicFormulaSkeleton>> CreatePredicatesDefinition()
        {
            return (
                from open in OpeningParenthesis
                from keyword in Parse.String(":predicates").Token()
                from skeletons in AtomicFormulaSkeleton.AtLeastOnce()
                from close in ClosingParenthesis
                select skeletons
                ).Token();
        }
        
        /// <summary>
        /// Wraps the specified option.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="option">The option.</param>
        /// <returns>IReadOnlyList&lt;T&gt;.</returns>
        static IReadOnlyList<T> Wrap<T>(IOption<IEnumerable<T>> option)
        {
            return option.IsDefined ? option.Get().ToList().AsReadOnly() : (IReadOnlyList<T>)new T[0];
        }

        /// <summary>
        /// Creates the axiom definition.
        /// </summary>
        /// <returns>Parser&lt;IAxiom&gt;.</returns>
        private Parser<IAxiom> CreateAxiomDefinition()
        {
            return (
                from open in OpeningParenthesis
                from keyword in Parse.String(":axiom").Token()
                from vars in Vars
                from context in Parse.String(":context").Token().Then(_ => GoalDescription)
                from implications in Parse.String(":implies").Token().Then(_ => LiteralOfTerm)
                from close in ClosingParenthesis
                select new Axiom(vars.ToList(), context, implications)
                ).Token();
        }
    }
}
