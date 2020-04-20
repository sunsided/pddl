using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model.Goals;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class GoalGrammar.
    /// </summary>
    internal static class GoalGrammar
    {
        /// <summary>
        /// The goal parser injector
        /// </summary>
        private static readonly ParserInjector<IGoalDescription> GoalParserInjector = new ParserInjector<IGoalDescription>();

        /// <summary>
        /// The goal description
        /// </summary>
        public static readonly Parser<IGoalDescription> GoalDescription =
            CreateGoalDescription();

        /// <summary>
        /// Creates the goal description.
        /// </summary>
        /// <returns>Parser&lt;IGoalDescription&gt;.</returns>
        private static Parser<IGoalDescription> CreateGoalDescription()
        {
            Parser<IGoalDescription> atomicGoalDescription =
                (from af in CommonGrammar.AtomicFormulaOfTerm
                 select new AtomicGoalDescription(af));

            Parser<IGoalDescription> literalGoalDesccription =
                (from l in CommonGrammar.LiteralOfTerm
                 select new LiteralGoalDescription(l));

            Parser<IGoalDescription> conjunctionGoalDescription =
                (
                    from open in CommonGrammar.OpeningParenthesis
                    from keyword in Keywords.And
                    from goals in GoalParserInjector.Parser.Many()
                    from close in CommonGrammar.ClosingParenthesis
                    select new ConjunctionGoalDescription(goals.ToArray())
                    ).Token();

            var goalDescription = literalGoalDesccription.Or(atomicGoalDescription).Or(conjunctionGoalDescription);
            GoalParserInjector.Parser = goalDescription;
            return goalDescription;
        }
    }
}
