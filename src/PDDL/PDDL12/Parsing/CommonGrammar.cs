using System;
using System.Collections.Generic;
using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.Types;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class CommonGrammar. This class cannot be inherited.
    /// </summary>
    internal static class CommonGrammar
    {
        /// <summary>
        /// This injector is used to fake-decouple the left recursive grammar construction
        /// </summary>
        private static readonly ParserInjector<IType> TypeParserInjector = new ParserInjector<IType>();

        /// <summary>
        /// Comments start with a semicolon and run until the end-of-line
        /// </summary>
        public static readonly Parser<string> Comment =
            Parse.Char(';').Once()
                .Concat(Parse.AnyChar.Until(Parse.LineTerminator))
                .Text();

        /// <summary>
        /// The opening parenthesis token
        /// </summary>
        public static readonly Parser<char> OpeningParenthesis = Parse.Char('(').Token();

        /// <summary>
        /// The closing parenthesis token
        /// </summary>
        public static readonly Parser<char> ClosingParenthesis = Parse.Char(')').Token();

        /// <summary>
        /// The name definition
        /// <para>
        /// letter followed by any alphanumeric, hyphen or underscore
        /// </para>
        /// </summary>
        public static readonly Parser<string> NameDefinition =
            Parse.Letter.AtLeastOnce()
            .Concat(Parse.Char('-')
            .Or(Parse.Char('_'))
            .Or(Parse.LetterOrDigit).Many())
            .Text();

        /// <summary>
        /// The name as non-token (i.e. for use in variable names)
        /// </summary>
        public static readonly Parser<IName> NameNonToken = (
            from value in NameDefinition
            select new Name(value));

        /// <summary>
        /// The type
        /// </summary>
        public static readonly Parser<IType> Type = CreateTypeDefinition();

        /// <summary>
        /// The variable name token
        /// </summary>
        public static readonly Parser<IName> VariableName = (
                from n in Parse.Char('?').Then(_ => NameNonToken)
                select n
                ).Token();

        /// <summary>
        /// The variable
        /// </summary>
        public static readonly Parser<IVariable> Variable = (
                from n in VariableName
                select new Variable(n)
                ).Token();

        /// <summary>
        /// The predicate
        /// </summary>
        public static readonly Parser<IPredicate> Predicate = (
                from value in NameDefinition
                select new Predicate(value))
                .Token();

        /// <summary>
        /// The term
        /// </summary>
        public static readonly Parser<ITerm> Term = NameNonToken.Token().Or<ITerm>(Variable);

        /// <summary>
        /// The atomic formula skeleton
        /// </summary>
        public static readonly Parser<IAtomicFormulaSkeleton> AtomicFormulaSkeleton = CreateAtomicFormulaSkeleton();

        /// <summary>
        /// The atomic formula of term
        /// </summary>
        public static readonly Parser<IAtomicFormula<ITerm>> AtomicFormulaOfTerm = (
            from open in OpeningParenthesis
            from p in Predicate
            from terms in Term.Many()
            from close in ClosingParenthesis
            select new AtomicFormula<ITerm>(p, terms.ToList())
        ).Token();

        /// <summary>
        /// The atomic formula of name
        /// </summary>
        public static readonly Parser<IAtomicFormula<IName>> AtomicFormulaOfName = (
            from open in OpeningParenthesis
            from p in Predicate
            from names in NameNonToken.Token().Many()
            from close in ClosingParenthesis
            select new AtomicFormula<IName>(p, names.ToList())
        ).Token();

        /// <summary>
        /// The literal of name
        /// </summary>
        public static readonly Parser<ILiteral<IName>> LiteralOfName = CreateLiteralOfName();

        /// <summary>
        /// The literal of term
        /// </summary>
        public static readonly Parser<ILiteral<ITerm>> LiteralOfTerm = CreateLiteralOfTerm();

        /// <summary>
        /// Wraps the specified option.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="option">The option.</param>
        /// <returns>IReadOnlyList&lt;T&gt;.</returns>
        internal static IReadOnlyList<T> Wrap<T>(IOption<IEnumerable<T>> option) =>
            option.IsDefined
                ? option.Get().ToList().AsReadOnly()
                : (IReadOnlyList<T>) ArraySegment<T>.Empty;

        /// <summary>
        /// Wraps the specified option.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="option">The option.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>IReadOnlyList&lt;T&gt;.</returns>
        internal static T Wrap<T>(IOption<T> option, T defaultValue) =>
            option.IsDefined
                ? option.Get()
                : defaultValue;

        /// <summary>
        /// Creates the type definition.
        /// </summary>
        /// <returns>Parser&lt;IType&gt;.</returns>
        private static Parser<IType> CreateTypeDefinition()
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
                from types in TypeParserInjector.Parser.AtLeastOnce().Token()
                from close in ClosingParenthesis
                select new EitherType(types.ToList())
                ).Token();

            // (fluent <type>) definition
            Parser<IType> fluentTypeDefinition = (
                from open in OpeningParenthesis
                from keyword in Parse.String("fluent").Token()
                from t in TypeParserInjector.Parser
                from close in ClosingParenthesis
                select new FluentType(t)
                ).Token();

            // final parser for types
            Parser<IType> type = typeDefinition.Or(eitherTypeDefinition).Or(fluentTypeDefinition);
            TypeParserInjector.Parser = type;

            return type;
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
                from keyword in Keywords.Not
                from af in AtomicFormulaOfName
                from close in ClosingParenthesis
                select new Literal<IName>(af.Name, af.Parameters, false))
                .Token();

            var literalName = positiveLiteralName.Or(negativeLiteralName);
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
                from keyword in Keywords.Not
                from af in AtomicFormulaOfTerm
                from close in ClosingParenthesis
                select new Literal<ITerm>(af.Name, af.Parameters, false))
                .Token();

            var literalTerm = positiveLiteralTerm.Or(negativeLiteralTerm);
            return literalTerm;
        }

        /// <summary>
        /// Creates the atomic formula skeleton.
        /// </summary>
        /// <returns>Parser&lt;AtomicFormulaSkeleton&gt;.</returns>
        private static Parser<IAtomicFormulaSkeleton> CreateAtomicFormulaSkeleton() =>
            (
                from open in OpeningParenthesis
                from p in Predicate
                from variables in TypedLists.TypedListOfVariable.Token()
                from close in ClosingParenthesis
                select new AtomicFormulaSkeleton(p, variables.ToList()))
            .Token();
    }
}
