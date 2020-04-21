using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model.Goals;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class GoalGrammar.
    /// </summary>
    internal sealed class GoalDescriptionParser : ParserBase<IGoalDescription>
    {
        public GoalDescriptionParser(ParenthesisParser parenthesisParser, KeywordParsers keywordParsers, AtomicFormulaOfTermParser atomicFormulaOfTermParser, LiteralOfTermParser literalOfTermParser)
        {
            Parser<IGoalDescription> atomicGoalDescription =
                (from af in atomicFormulaOfTermParser.Parser
                    select new AtomicGoalDescription(af));

            Parser<IGoalDescription> literalGoalDescription =
                (from l in literalOfTermParser.Parser
                    select new LiteralGoalDescription(l));

            Parser<IGoalDescription> conjunctionGoalDescription =
            (
                from open in parenthesisParser.Opening
                from keyword in keywordParsers.And
                from goals in Parser.Many()
                from close in parenthesisParser.Closing
                select new ConjunctionGoalDescription(goals.ToArray())
            ).Token();

            Parser = literalGoalDescription.Or(atomicGoalDescription).Or(conjunctionGoalDescription);
        }

        /// <summary>
        /// The goal description
        /// </summary>
        public override Parser<IGoalDescription> Parser { get; }
    }
}
