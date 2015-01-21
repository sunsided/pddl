using System.Collections.Generic;
using System.Linq;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Effects;
using PDDL.Model.Pddl12.Goals;
using PDDL.Model.Pddl12.Types;
using Sprache;

namespace PDDL.Parser
{
    /// <summary>
    /// Class Pddl12Grammar. This class cannot be inherited.
    /// </summary>
    sealed class Pddl12Grammar
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Pddl12Grammar"/> class.
        /// </summary>
        public Pddl12Grammar()
        {
            ConstructGrammar();
        }

        /// <summary>
        /// Comments start with a semicolon and run until the eol
        /// </summary>
        private static readonly Parser<string> _comment =
            Parse.Char(';').Once()
            .Concat(Parse.AnyChar.Until(Parse.LineTerminator))
            .Text();

        /// <summary>
        /// The opening parenthesis
        /// </summary>
        internal static readonly Parser<char> OpeningParenthesis = Parse.Char('(').Token();

        /// <summary>
        /// The closing parenthesis
        /// </summary>
        internal static readonly Parser<char> ClosingParenthesis = Parse.Char(')').Token();

        /// <summary>
        /// The name definition
        /// <para>
        /// letter followed by any alphanumeric, hyphen or underscore
        /// </para>
        /// </summary>
        internal static readonly Parser<string> NameDefinition = Parse.Letter.AtLeastOnce()
            .Concat(Parse.Char('-').Or(Parse.Char('_')).Or(Parse.LetterOrDigit).Many()).Text();

        /// <summary>
        /// The name
        /// </summary>
        internal static readonly Parser<IName> NameNonToken = (
            from value in NameDefinition 
            select new Name(value));

        /// <summary>
        /// The type
        /// </summary>
        internal Parser<IType> Type;

        /// <summary>
        /// The valid requirements
        /// </summary>
        internal static Parser<IRequirement> ValidRequirements =
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
                     .Or(Parse.String(":dag-expansions"))
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
        /// The variable name token
        /// </summary>
        internal static readonly Parser<IName> VariableName = (
                from n in Parse.Char('?').Then(_ => NameNonToken)
                select n
                ).Token();

        /// <summary>
        /// The variable
        /// </summary>
        internal static readonly Parser<IVariable> Variable = (
                from n in VariableName
                select new Variable(n)
                ).Token();

        /// <summary>
        /// <typed list (variable)>
        /// </summary>
        internal Parser<IEnumerable<IVariable>> TypedListOfVariable;

        /// <summary>
        /// The predicate
        /// </summary>
        internal static Parser<IPredicate> Predicate = (
                from value in NameDefinition
                select new Predicate(value))
                .Token();

        /// <summary>
        /// The atomic formula skeleton
        /// </summary>
        internal Parser<IAtomicFormulaSkeleton> AtomicFormulaSkeleton;

        internal Parser<IEnumerable<IAtomicFormulaSkeleton>> PredicatesDefinition;

        internal Parser<IEnumerable<IName>> ExtensionDefinition;

        internal Parser<IEnumerable<IRequirement>> RequirementsDefinition;

        internal Parser<IEnumerable<IType>> TypedListOfType;

        internal Parser<IEnumerable<IType>> TypesDefinition;

        /// <summary>
        /// Constructs the grammar.
        /// </summary>
        private void ConstructGrammar()
        {
            Type = CreateTypeDefinition();
            TypedListOfVariable = CreateTypedListOfVariable();
            AtomicFormulaSkeleton = CreateAtomicFormulaSkeleton();
            PredicatesDefinition = CreatePredicatesDefinition();
            ExtensionDefinition = CreateExtensionDefinition();
            RequirementsDefinition = CreateRequirementsDefinition();
            TypedListOfType = CreateTypedListOfType();

            TypesDefinition = CreateTypesDefinition();

            var typedListConstant = (
                from names in NameNonToken.Token().AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => Type).Token().Optional()
                select names.Select(vn => new Constant(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));

            Parser<IEnumerable<IConstant>> constantsDef = (
               from open in OpeningParenthesis
               from keyword in Parse.String(":constants").Token()
               from types in typedListConstant
               from close in ClosingParenthesis
               select types
               ).Token();

            // TODO: implement domain-vars-def 

            Parser<ITerm> term = NameNonToken.Token().Or<ITerm>(Variable);

            #region literal(term)

            Parser<IAtomicFormula> atomicFormulaTerm = (
                from open in OpeningParenthesis
                from p in Predicate
                from terms in term.Many()
                from close in ClosingParenthesis
                select new AtomicFormula(p, terms.ToList())
               ).Token();

            Parser<ILiteral> positiveLiteralTerm = (
                from af in atomicFormulaTerm
                select new Literal(af.Name, af.Parameters, true))
                .Token();

            Parser<ILiteral> negativeLiteralTerm = (
                from open in OpeningParenthesis
                from keyword in Parse.String("not").Token()
                from af in atomicFormulaTerm
                from close in ClosingParenthesis
                select new Literal(af.Name, af.Parameters, false))
                .Token();

            Parser<ILiteral> literalTerm = positiveLiteralTerm.Or(negativeLiteralTerm);

            #endregion

            #region literal(name)

            Parser<IAtomicFormula> atomicFormulaName = (
                from open in OpeningParenthesis
                from p in Predicate
                from terms in NameNonToken.Token().Many()
                from close in ClosingParenthesis
                select new AtomicFormula(p, terms.ToList())
               ).Token();

            Parser<ILiteral> positiveLiteralName = (
                from af in atomicFormulaName
                select new Literal(af.Name, af.Parameters, true))
                .Token();

            Parser<ILiteral> negativeLiteralName = (
                from open in OpeningParenthesis
                from keyword in Parse.String("not").Token()
                from af in atomicFormulaName
                from close in ClosingParenthesis
                select new Literal(af.Name, af.Parameters, false))
                .Token();

            Parser<ILiteral> literalName = positiveLiteralName.Or(negativeLiteralName);

            #endregion

            Parser<IGoalDescription> atomicGoalDescription =
                (from af in atomicFormulaTerm
                 select new AtomicGoalDescription(af));

            Parser<IGoalDescription> literalGoalDesccription =
                (from l in literalTerm
                 select new LiteralGoalDescription(l));

            var gdi = new ParserInjector<IGoalDescription>();

            Parser<IGoalDescription> conjunctionGoalDescription =
                (
                    from open in OpeningParenthesis
                    from keyword in Parse.String("and").Token()
                    from goals in gdi.Parser.Many()
                    from close in ClosingParenthesis
                    select new ConjunctionGoalDescription(goals.ToArray())
                    ).Token();

            var goalDescription = literalGoalDesccription.Or(atomicGoalDescription).Or(conjunctionGoalDescription);
            gdi.Parser = goalDescription;

            // TODO add :disjunctive-preconditions goals
            // TODO add :existential-preconditions goals
            // TODO add :universal-preconditions goals

            var timelessDef = (
               from open in OpeningParenthesis
               from keyword in Parse.String(":timeless").Token()
               from literals in literalName.Many()
               from close in ClosingParenthesis
               select literals
               ).Token();

            // TODO: add :domain-axioms
            // TODO: add :action-expansions

            var actionFunctor = NameNonToken.Token();

            var actionPreconditions = (
                from keyword in Parse.String(":precondition").Token()
                from precondition in goalDescription
                select precondition
                ).Token();

            var actionParameters = (
                from keyword in Parse.String(":parameters").Token()
                from open in OpeningParenthesis
                from variables in TypedListOfVariable.Token()
                from close in ClosingParenthesis
                select variables
                ).Token();

            var actionVars = (
                from keyword in Parse.String(":vars").Token()
                from open in OpeningParenthesis
                from variables in TypedListOfVariable.Token()
                from close in ClosingParenthesis
                select variables
                ).Token();

            Parser<IEffect> positiveEffect =
               (from af in atomicFormulaTerm
                select new PositiveEffect(af)).Token();

            Parser<IEffect> negativeEffect =
                 (
                 from open in OpeningParenthesis
                 from keyword in Parse.String("not").Token()
                 from af in atomicFormulaTerm
                 from close in ClosingParenthesis
                 select new NegativeEffect(af)).Token();

            var edi = new ParserInjector<IEffect>();

            Parser<IEffect> conjunctionEffect =
                (
                    from open in OpeningParenthesis
                    from keyword in Parse.String("and").Token()
                    from effects in edi.Parser.Many()
                    from close in ClosingParenthesis
                    select new ConjunctionEffect(effects.ToArray())
                    ).Token();

            var effect = positiveEffect.Or(negativeEffect).Or(conjunctionEffect);
            edi.Parser = effect;

            Parser<IEffect> effectDef = (
                from keyword in Parse.String(":effect").Token()
                from e in effect.Token()
                select e
                ).Token();

            var actionDef = (
                from open in OpeningParenthesis
                from keyword in Parse.String(":action").Token()
                from functor in actionFunctor
                from parameters in actionParameters
                // action-def body following
                from vars in actionVars.Optional()
                from precs in actionPreconditions.Optional()
                from e in effectDef.Optional()
                from close in ClosingParenthesis
                select new Action(functor, parameters.ToList(), (e.IsDefined ? e.Get() : NullEffect.Default))
                {
                    Variables = Wrap(vars)
                }
                ).Token();

            Parser<IDomain> domainDef =
                (
                    from open in OpeningParenthesis
                    from domainKeyword in Parse.String("domain").Token()
                    from domainName in NameNonToken.Token()
                    from close in ClosingParenthesis
                    from extensions in ExtensionDefinition.Optional()
                    from requirements in RequirementsDefinition.Optional()
                    from types in TypesDefinition.Optional()
                    from constants in constantsDef.Optional()
                    from predicates in PredicatesDefinition.Optional()
                    from timeless in timelessDef.Optional()
                    // structure-def following
                    from actions in actionDef.Many()

                    // bundle and go
                    let ex = Wrap(extensions)
                    let dr = Wrap(requirements)
                    let ty = Wrap(types)
                    let co = Wrap(constants)
                    let pr = Wrap(predicates)
                    let tl = Wrap(timeless)
                    select new Domain(domainName, dr, ty, co, pr, tl)
                    );

            var defineDef =
                (
                    from openDefine in OpeningParenthesis
                    from defineKeyword in Parse.String("define").Token()
                    from domain in domainDef
                    from closeDefine in ClosingParenthesis
                    select domain
                    );
        }

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

        private Parser<IEnumerable<CustomType>> CreateTypedListOfType()
        {
            return (
                from names in NameNonToken.Token().AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => Type).Token().Optional()
                select names.Select(vn => new CustomType(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
        }

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
        /// Creates the atomic formula skeleton.
        /// </summary>
        /// <returns>Parser&lt;AtomicFormulaSkeleton&gt;.</returns>
        private Parser<AtomicFormulaSkeleton> CreateAtomicFormulaSkeleton()
        {
            return (
                from open in OpeningParenthesis
                from p in Predicate
                from variables in TypedListOfVariable.Token()
                from close in ClosingParenthesis
                select new AtomicFormulaSkeleton(p, variables.ToList()))
                .Token();
        }

        /// <summary>
        /// Creates the <typed list (variable)>
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;Variable&gt;&gt;.</returns>
        private Parser<IEnumerable<Variable>> CreateTypedListOfVariable()
        {
            return (
                from vns in VariableName.AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => Type).Token().Optional()
                select vns.Select(vn => new Variable(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                .Select(groupedPerType => groupedPerType.SelectMany(v => v));
        }

        /// <summary>
        /// This injector is used to fake-decouple the left recursive grammar construction
        /// </summary>
        private readonly ParserInjector<IType> _typeParserInjector = new ParserInjector<IType>();

        /// <summary>
        /// Creates the type definition.
        /// </summary>
        /// <returns>Parser&lt;IType&gt;.</returns>
        private Parser<IType> CreateTypeDefinition()
        {
            // Simple type definition
            Parser<IType> typeDefinition = (
                from value in NameNonToken
                select new CustomType(value)
                ).Token();

            // (either <type>+) definition
            Parser<IType> eitherTypeDefinition = (
                from open in OpeningParenthesis
                from keyword in Parse.String("either").Token()
                from types in _typeParserInjector.Parser.AtLeastOnce().Token()
                from close in ClosingParenthesis
                select new EitherType(types.ToList())
                ).Token();

            // (fluent <type>) definition
            Parser<IType> fluentTypeDefinition = (
                from open in OpeningParenthesis
                from keyword in Parse.String("fluent").Token()
                from t in _typeParserInjector.Parser
                from close in ClosingParenthesis
                select new FluentType(t)
                ).Token();

            // final parser for types
            Parser<IType> type = typeDefinition.Or(eitherTypeDefinition).Or(fluentTypeDefinition);
            _typeParserInjector.Parser = type;

            return type;
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
        /// Class ParserInjector. This class cannot be inherited.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        sealed class ParserInjector<T>
        {
            /// <summary>
            /// Gets or sets the parser.
            /// </summary>
            /// <value>The parser.</value>
            public Parser<T> Parser { get; set; }
        }
    }
}
