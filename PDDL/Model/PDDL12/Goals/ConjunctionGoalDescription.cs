using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Goals
{
    /// <summary>
    /// Class ConjunctionGoalDescription.
    /// </summary>
    public class ConjunctionGoalDescription : GoalBase, IConjunctionGoalDescription
    {
        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <value>The goals.</value>
        public IReadOnlyList<IGoalDescription> Goals { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConjunctionGoalDescription"/> class.
        /// </summary>
        /// <param name="goals">The goals.</param>
        /// <exception cref="ArgumentNullException">The value of 'goals' cannot be null. </exception>
        public ConjunctionGoalDescription([NotNull] IReadOnlyList<IGoalDescription> goals)
        {
            if (ReferenceEquals(goals, null)) throw new ArgumentNullException("goals", "goals must not be null");
            Goals = goals;
        }
    }
}
