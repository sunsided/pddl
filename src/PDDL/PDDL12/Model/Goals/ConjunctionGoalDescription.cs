using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Goals;

namespace PDDL.PDDL12.Model.Goals
{
    /// <summary>
    /// Class ConjunctionGoalDescription.
    /// </summary>
    internal sealed class ConjunctionGoalDescription : GoalBase, IConjunctionGoalDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConjunctionGoalDescription"/> class.
        /// </summary>
        /// <param name="goals">The goals.</param>
        /// <exception cref="ArgumentNullException">The value of 'goals' cannot be null. </exception>
        public ConjunctionGoalDescription(IReadOnlyList<IGoalDescription> goals)
        {
            Goals = goals ?? throw new ArgumentNullException(nameof(goals), "goals must not be null");
        }

        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <value>The goals.</value>
        public IReadOnlyList<IGoalDescription> Goals { get; }

        /// <summary>
        /// Gets the kind of goal.
        /// </summary>
        /// <value>The kind.</value>
        public override GoalKind Kind => GoalKind.Conjunction;
    }
}
