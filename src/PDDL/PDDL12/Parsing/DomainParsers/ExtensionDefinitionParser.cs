using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class ExtensionDefinitionParser.
    /// </summary>
    internal sealed class ExtensionDefinitionParser : ParserBase<IDomainExtensionDefinition>
    {
        public ExtensionDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, NameNonTokenParser nameNonTokenParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CExtends
                from names in nameNonTokenParser.Token().AtLeastOnce()
                from close in parenthesis.Closing
                select new ExtensionDefinition(names.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainExtensionDefinition> Parser { get; }
    }
}
