using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Class Preconditions.
    /// </summary>
    public class Precondition : IPrecondition
    {
        /// <summary>
        /// Gets the preconditions.
        /// </summary>
        /// <value>The preconditions.</value>
        public IGoalDescription Preconditions { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Precondition"/> class.
        /// </summary>
        /// <param name="preconditions">The preconditions.</param>
        /// <exception cref="ArgumentNullException">The value of 'preconditions' cannot be null. </exception>
        public Precondition([NotNull] IGoalDescription preconditions)
        {
            if (ReferenceEquals(preconditions, null)) throw new ArgumentNullException("preconditions", "preconditions must not be null");
            Preconditions = preconditions;
        }
    }
}
