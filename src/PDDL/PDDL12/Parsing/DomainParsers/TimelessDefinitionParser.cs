using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class TimelessDefinitionParser.
    /// </summary>
    internal sealed class TimelessDefinitionParser : ParserBase<IDomainTimelessDefinition>
    {
        public TimelessDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, LiteralOfNameParser literalOfNameParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CTimeless
                from literals in literalOfNameParser.Many()
                from close in parenthesis.Closing
                select new TimelessDefinition(literals.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainTimelessDefinition> Parser { get; }
    }
}
