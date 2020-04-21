using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using PDDL.PDDL12.Parsing.TypedListParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class TypesDefinitionParser.
    /// </summary>
    internal sealed class TypesDefinitionParser : ParserBase<IDomainTypesDefinition>
    {
        public TypesDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, TypedListOfTypeParser typedListOfTypeParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CTypes
                from types in typedListOfTypeParser.Parser
                from close in parenthesis.Closing
                select new TypesDefinition(types.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainTypesDefinition> Parser { get; }
    }
}
