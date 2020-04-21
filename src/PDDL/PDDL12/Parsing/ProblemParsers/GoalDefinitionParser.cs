using PDDL.PDDL12.Abstractions.Goals;
using PDDL.PDDL12.Model.ProblemElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.ProblemParsers
{
    /// <summary>
    /// Class GoalDefinitionParser.
    /// </summary>
    internal sealed class GoalDefinitionParser : ParserBase<IProblemGoalDefinition>
    {
        public GoalDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, GoalDescriptionParser goalDescriptionParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CGoal
                from goal in goalDescriptionParser.Parser
                from close in parenthesis.Closing
                select new ProblemGoalDefinition(goal)
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IProblemGoalDefinition> Parser { get; }
    }
}
