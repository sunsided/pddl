using System.Collections.Generic;
using System.Linq;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Effects;
using PDDL.Model.Pddl12.Goals;
using PDDL.Model.Pddl12.Null;
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
            // TODO: implement domain-vars-def 
            // TODO add :disjunctive-preconditions goals
            // TODO add :existential-preconditions goals
            // TODO add :universal-preconditions goals
            // TODO: add :domain-axioms
            // TODO: add :action-expansions

            Type = CreateTypeDefinition();
            TypedListOfVariable = CreateTypedListOfVariable();
            AtomicFormulaSkeleton = CreateAtomicFormulaSkeleton();
            PredicatesDefinition = CreatePredicatesDefinition();
            ExtensionDefinition = CreateExtensionDefinition();
            RequirementsDefinition = CreateRequirementsDefinition();
            TypedListOfType = CreateTypedListOfType();
            TypesDefinition = CreateTypesDefinition();
            TypedListOfConstant = CreateTypedListOfConstant();
            ConstantsDefinition = CreateConstantsDefinition();

            LiteralOfTerm = CreateLiteralOfTerm();
            LiteralOfName = CreateLiteralOfName();
            GoalDescription = CreateGoalDescription();
            TimelessDefinition = CreateTimelessDefinition();
            Effect = CreateEffect();
            ActionDefinition = CreateActionDefinition();
            DomainDefinition = CreateDomainDefinition();
            DefineDefinition = CreateDefineDefinition();
        }

        /// <summary>
        /// Comments start with a semicolon and run until the eol
        /// </summary>
        internal static readonly Parser<string> Comment =
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
        internal readonly Parser<IType> Type;

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
        /// typed list (variable)
        /// </summary>
        internal readonly Parser<IEnumerable<IVariableDefinition>> TypedListOfVariable;

        /// <summary>
        /// The predicate
        /// </summary>
        internal readonly static Parser<IPredicate> Predicate = (
                from value in NameDefinition
                select new Predicate(value))
                .Token();

        /// <summary>
        /// The atomic formula skeleton
        /// </summary>
        internal readonly Parser<IAtomicFormulaSkeleton> AtomicFormulaSkeleton;

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
        /// The typed list of type
        /// </summary>
        internal readonly Parser<IEnumerable<IType>> TypedListOfType;

        /// <summary>
        /// The types definition
        /// </summary>
        internal readonly Parser<IEnumerable<IType>> TypesDefinition;

        /// <summary>
        /// The typed list of constant
        /// </summary>
        internal readonly Parser<IEnumerable<IConstant>> TypedListOfConstant;

        /// <summary>
        /// The constants definition
        /// </summary>
        internal readonly Parser<IEnumerable<IConstant>> ConstantsDefinition;

        /// <summary>
        /// The term
        /// </summary>
        internal static readonly Parser<ITerm> Term = NameNonToken.Token().Or<ITerm>(Variable);

        /// <summary>
        /// The atomic formula of term
        /// </summary>
        internal static Parser<IAtomicFormula<ITerm>> AtomicFormulaOfTerm = (
                from open in OpeningParenthesis
                from p in Predicate
                from terms in Term.Many()
                from close in ClosingParenthesis
                select new AtomicFormula<ITerm>(p, terms.ToList())
               ).Token();

        /// <summary>
        /// The literal of term
        /// </summary>
        internal readonly Parser<ILiteral<ITerm>> LiteralOfTerm;

        /// <summary>
        /// The atomic formula of name
        /// </summary>
        internal static Parser<IAtomicFormula<IName>> AtomicFormulaOfName = (
                from open in OpeningParenthesis
                from p in Predicate
                from names in NameNonToken.Token().Many()
                from close in ClosingParenthesis
                select new AtomicFormula<IName>(p, names.ToList())
               ).Token();

        /// <summary>
        /// The literal of name
        /// </summary>
        internal readonly Parser<ILiteral<IName>> LiteralOfName;

        /// <summary>
        /// The goal description
        /// </summary>
        internal readonly Parser<IGoalDescription> GoalDescription;

        /// <summary>
        /// The timeless definition
        /// </summary>
        internal readonly Parser<IEnumerable<ILiteral<IName>>> TimelessDefinition;

        /// <summary>
        /// The action definition
        /// </summary>
        internal readonly Parser<Action> ActionDefinition;

        /// <summary>
        /// The domain definition
        /// </summary>
        internal readonly Parser<IDomain> DomainDefinition;

        /// <summary>
        /// The effect
        /// </summary>
        internal readonly Parser<IEffect> Effect;

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
        /// Creates the domain definition.
        /// </summary>
        /// <returns>Parser&lt;Domain&gt;.</returns>
        private Parser<Domain> CreateDomainDefinition()
        {
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
                from actions in ActionDefinition.Many()

                // bundle and go
                let ex = Wrap(extensions)
                let dr = Wrap(requirements)
                let ty = Wrap(types)
                let co = Wrap(constants)
                let pr = Wrap(predicates)
                let tl = Wrap(timeless)
                select new Domain(domainName, dr, ty, co, pr, tl)
                );
        }

        /// <summary>
        /// Creates the action definition.
        /// </summary>
        /// <returns>Parser&lt;Action&gt;.</returns>
        private Parser<Action> CreateActionDefinition()
        {
            var actionFunctor = NameNonToken.Token();

            var actionPreconditions = (
                from keyword in Parse.String(":precondition").Token()
                from precondition in GoalDescription
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

            var effectDef = (
                from keyword in Parse.String(":effect").Token()
                from e in Effect.Token()
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

            return actionDef;
        }

        /// <summary>
        /// The effect parser injector
        /// </summary>
        private readonly ParserInjector<IEffect> _effectParserInjector = new ParserInjector<IEffect>();

        /// <summary>
        /// Creates the effect.
        /// </summary>
        /// <returns>Parser&lt;IEffect&gt;.</returns>
        private Parser<IEffect> CreateEffect()
        {
            Parser<IEffect> positiveEffect =
                (from af in AtomicFormulaOfTerm
                    select new PositiveEffect(af)).Token();

            Parser<IEffect> negativeEffect =
                (
                    from open in OpeningParenthesis
                    from keyword in Parse.String("not").Token()
                    from af in AtomicFormulaOfTerm
                    from close in ClosingParenthesis
                    select new NegativeEffect(af)).Token();

            Parser<IEffect> conjunctionEffect =
                (
                    from open in OpeningParenthesis
                    from keyword in Parse.String("and").Token()
                    from effects in _effectParserInjector.Parser.Many()
                    from close in ClosingParenthesis
                    select new ConjunctionEffect(effects.ToArray())
                    ).Token();

            var effect = positiveEffect.Or(negativeEffect).Or(conjunctionEffect);
            _effectParserInjector.Parser = effect;
            return effect;
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

        private readonly ParserInjector<IGoalDescription> _goalParserInjector = new ParserInjector<IGoalDescription>();

        /// <summary>
        /// Creates the goal description.
        /// </summary>
        /// <returns>Parser&lt;IGoalDescription&gt;.</returns>
        private Parser<IGoalDescription> CreateGoalDescription()
        {
            Parser<IGoalDescription> atomicGoalDescription =
                (from af in AtomicFormulaOfTerm
                    select new AtomicGoalDescription(af));

            Parser<IGoalDescription> literalGoalDesccription =
                (from l in LiteralOfTerm
                    select new LiteralGoalDescription(l));
            
            Parser<IGoalDescription> conjunctionGoalDescription =
                (
                    from open in OpeningParenthesis
                    from keyword in Parse.String("and").Token()
                    from goals in _goalParserInjector.Parser.Many()
                    from close in ClosingParenthesis
                    select new ConjunctionGoalDescription(goals.ToArray())
                    ).Token();

            var goalDescription = literalGoalDesccription.Or(atomicGoalDescription).Or(conjunctionGoalDescription);
            _goalParserInjector.Parser = goalDescription;
            return goalDescription;
        }

        /// <summary>
        /// Creates the literal(name)
        /// </summary>
        /// <returns>Parser&lt;ILiteral&gt;.</returns>
        private static Parser<ILiteral<IName>> CreateLiteralOfName()
        {
            Parser<ILiteral<IName>> positiveLiteralName = (
                from af in AtomicFormulaOfName
                select new Literal<IName>(af.Name, af.Parameters, true))
                .Token();

            Parser<ILiteral<IName>> negativeLiteralName = (
                from open in OpeningParenthesis
                from keyword in Parse.String("not").Token()
                from af in AtomicFormulaOfName
                from close in ClosingParenthesis
                select new Literal<IName>(af.Name, af.Parameters, false))
                .Token();

            Parser<ILiteral<IName>> literalName = positiveLiteralName.Or(negativeLiteralName);
            return literalName;
        }

        /// <summary>
        /// Creates the literal of term.
        /// </summary>
        /// <returns>Parser&lt;ILiteral&gt;.</returns>
        private static Parser<ILiteral<ITerm>> CreateLiteralOfTerm()
        {
            Parser<ILiteral<ITerm>> positiveLiteralTerm = (
                from af in AtomicFormulaOfTerm
                select new Literal<ITerm>(af.Name, af.Parameters, true))
                .Token();

            Parser<ILiteral<ITerm>> negativeLiteralTerm = (
                from open in OpeningParenthesis
                from keyword in Parse.String("not").Token()
                from af in AtomicFormulaOfTerm
                from close in ClosingParenthesis
                select new Literal<ITerm>(af.Name, af.Parameters, false))
                .Token();

            Parser<ILiteral<ITerm>> literalTerm = positiveLiteralTerm.Or(negativeLiteralTerm);
            return literalTerm;
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
        /// Creates the typed list of constant.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;Constant&gt;&gt;.</returns>
        private Parser<IEnumerable<Constant>> CreateTypedListOfConstant()
        {
            return (
                from names in NameNonToken.Token().AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => Type).Token().Optional()
                select names.Select(vn => new Constant(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
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
        /// Creates the type list (type)
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;CustomType&gt;&gt;.</returns>
        private Parser<IEnumerable<CustomType>> CreateTypedListOfType()
        {
            return (
                from names in NameNonToken.Token().AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => Type).Token().Optional()
                select names.Select(vn => new CustomType(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
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
        /// Creates the typed list (variable)
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;Variable&gt;&gt;.</returns>
        private Parser<IEnumerable<IVariableDefinition>> CreateTypedListOfVariable()
        {
            return (
                from vns in VariableName.AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => Type).Token().Optional()
                select vns.Select(vn => new VariableDefinition(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
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
