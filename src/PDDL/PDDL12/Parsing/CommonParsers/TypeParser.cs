using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model.Types;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// Creates the type definition.
    /// </summary>
    internal sealed class TypeParser : ParserBase<IType>
    {
        public TypeParser(ParenthesisParser parenthesisParser, NameNonTokenParser nameNonTokenParser)
        {
            // Simple type definition
            Parser<IType> typeDefinition = (
                from value in nameNonTokenParser.Parser
                select new CustomType(value)
            ).Token();

            // (either <type>+) definition
            Parser<IType> eitherTypeDefinition = (
                from open in parenthesisParser.Opening
                from keyword in Parse.String("either").Token()
                from types in Parse.Ref(() => Parser).AtLeastOnce().Token() // Recursive definition
                from close in parenthesisParser.Closing
                select new EitherType(types.ToList())
            ).Token();

            // (fluent <type>) definition
            Parser<IType> fluentTypeDefinition = (
                from open in parenthesisParser.Opening
                from keyword in Parse.String("fluent").Token()
                from t in Parse.Ref(() => Parser) // Recursive definition
                from close in parenthesisParser.Closing
                select new FluentType(t)
            ).Token();

            // final parser for types
            Parser = typeDefinition.Or(eitherTypeDefinition).Or(fluentTypeDefinition);
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IType> Parser { get; }

    }
}
