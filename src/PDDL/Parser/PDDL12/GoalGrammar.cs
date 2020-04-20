using System.Linq;
using JetBrains.Annotations;
using PDDL.Model.PDDL12;
using PDDL.Model.PDDL12.Goals;
using Sprache;

namespace PDDL.Parser.PDDL12
{
    /// <summary>
    /// Class GoalGrammar.
    /// </summary>
    internal static class GoalGrammar
    {
        #region Internal Helpers

        /// <summary>
        /// The goal parser injector
        /// </summary>
        [NotNull]
        private static readonly ParserInjector<IGoalDescription> _goalParserInjector = new ParserInjector<IGoalDescription>();

        #endregion

        /// <summary>
        /// The goal description
        /// </summary>
        [NotNull]
        public static readonly Parser<IGoalDescription> GoalDescription =
            CreateGoalDescription();

        #region Factory Functions
        
        /// <summary>
        /// Creates the goal description.
        /// </summary>
        /// <returns>Parser&lt;IGoalDescription&gt;.</returns>
        [NotNull]
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
                    from goals in _goalParserInjector.Parser.Many()
                    from close in CommonGrammar.ClosingParenthesis
                    select new ConjunctionGoalDescription(goals.ToArray())
                    ).Token();

            var goalDescription = literalGoalDesccription.Or(atomicGoalDescription).Or(conjunctionGoalDescription);
            _goalParserInjector.Parser = goalDescription;
            return goalDescription;
        }

        #endregion Factory Functions
    }
}
