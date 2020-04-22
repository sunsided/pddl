using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class RequirementsDefinitionParser.
    /// </summary>
    internal sealed class DomainRequirementsDefinitionParser : ParserBase<IDomainRequireDefinition>
    {
        public DomainRequirementsDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, RequirementParser requirementParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CRequirements
                from keys in requirementParser.AtLeastOnce()
                from close in parenthesis.Closing
                select new DomainRequireDefinition(keys.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainRequireDefinition> Parser { get; }
    }
}
