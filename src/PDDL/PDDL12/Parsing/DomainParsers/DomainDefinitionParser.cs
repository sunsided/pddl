using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class DomainDefinitionParser.
    /// </summary>
    internal sealed class DomainDefinitionParser : ParserBase<IDomain>
    {
        public DomainDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, NameNonTokenParser nameNonTokenParser,
            DomainDefinitionElementsParser domainDefinitionElementsParser)
        {
            Parser =
                // header
                from open in parenthesis.Opening
                from domainKeyword in keywordParsers.Domain
                from domainName in nameNonTokenParser.Token()
                from close in parenthesis.Closing
                // definition body
                from body in domainDefinitionElementsParser.Parser
                // bundle and go
                select DomainFactory.FromSequence(domainName, body);
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomain> Parser { get; }
    }
}
