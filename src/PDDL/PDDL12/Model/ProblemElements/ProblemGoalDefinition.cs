using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Goals;

namespace PDDL.PDDL12.Model.ProblemElements
{
    /// <summary>
    /// Class ProblemGoalDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ProblemGoalDefinition : IProblemGoalDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemGoalDefinition"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public ProblemGoalDefinition(IGoalDescription value)
        {
            Goal = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the goal.
        /// </summary>
        /// <value>The goal.</value>
        public IGoalDescription Goal{ get; }
    }
}
