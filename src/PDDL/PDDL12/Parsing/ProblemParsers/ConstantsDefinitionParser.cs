using System.Linq;
using PDDL.PDDL12.Abstractions.Problems;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.ProblemParsers
{
    /// <summary>
    /// Class RequirementsDefinitionParser.
    /// </summary>
    internal sealed class RequirementsDefinitionParser : ParserBase<IProblemRequireDefinition>
    {
        public RequirementsDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, RequirementsParser requirementsParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CRequirements
                from keys in requirementsParser.Many()
                from close in parenthesis.Closing
                select new RequirementsDefinition(keys.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IProblemRequireDefinition> Parser { get; }
    }
}
