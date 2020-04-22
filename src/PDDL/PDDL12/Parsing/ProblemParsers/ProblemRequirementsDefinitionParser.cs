using System.Linq;
using PDDL.PDDL12.Abstractions.Problems;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Model.ProblemElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.ProblemParsers
{
    /// <summary>
    /// Class RequirementsDefinitionParser.
    /// </summary>
    internal sealed class ProblemRequirementsDefinitionParser : ParserBase<IProblemRequireDefinition>
    {
        public ProblemRequirementsDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, RequirementParser requirementParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CRequirements
                from keys in requirementParser.AtLeastOnce()
                from close in parenthesis.Closing
                select new ProblemRequireDefinition(keys.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IProblemRequireDefinition> Parser { get; }
    }
}
