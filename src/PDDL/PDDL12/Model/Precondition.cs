using System;
using PDDL.PDDL12.Abstractions;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class Preconditions.
    /// </summary>
    internal sealed class Precondition : IPrecondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Precondition"/> class.
        /// </summary>
        /// <param name="preconditions">The preconditions.</param>
        /// <exception cref="ArgumentNullException">The value of 'preconditions' cannot be null. </exception>
        public Precondition(IGoalDescription preconditions)
        {
            Preconditions = preconditions ?? throw new ArgumentNullException(nameof(preconditions), "preconditions must not be null");
        }

        /// <summary>
        /// Gets the preconditions.
        /// </summary>
        /// <value>The preconditions.</value>
        public IGoalDescription Preconditions { get; }
    }
}
