using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class SafetyDefinitionParser.
    /// </summary>
    internal sealed class SafetyDefinitionParser : ParserBase<IDomainSafetyDefinition>
    {
        public SafetyDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, GoalDescriptionParser goalDescriptionParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CSafety
                from backgroundGoals in goalDescriptionParser.Many()
                from close in parenthesis.Closing
                select new SafetyDefinition(backgroundGoals.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainSafetyDefinition> Parser { get; }
    }
}
