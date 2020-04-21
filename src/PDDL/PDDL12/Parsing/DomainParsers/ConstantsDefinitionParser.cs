using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using PDDL.PDDL12.Parsing.TypedListParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class ConstantsDefinitionParser.
    /// </summary>
    internal sealed class ConstantsDefinitionParser : ParserBase<IDomainConstantsDefinition>
    {
        public ConstantsDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, TypedListOfConstantParser typedListOfConstantParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CConstants
                from constants in typedListOfConstantParser.Parser
                from close in parenthesis.Closing
                select new ConstantsDefinition(constants.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainConstantsDefinition> Parser { get; }
    }
}
