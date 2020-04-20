using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class Preconditions.
    /// </summary>
    public class Precondition : IPrecondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Precondition"/> class.
        /// </summary>
        /// <param name="preconditions">The preconditions.</param>
        /// <exception cref="ArgumentNullException">The value of 'preconditions' cannot be null. </exception>
        public Precondition([NotNull] IGoalDescription preconditions)
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
