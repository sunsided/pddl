using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class SafetyDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class SafetyDefinition : IDomainSafetyDefinition
    {
        /// <summary>
        /// Gets the safety constraints.
        /// </summary>
        /// <value>The safety constraints.</value>
        [NotNull]
        public IReadOnlyList<IGoalDescription> Safety { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SafetyDefinition"/> class.
        /// </summary>
        /// <param name="safety">The safety.</param>
        /// <exception cref="ArgumentNullException">The value of 'safety' cannot be null. </exception>
        public SafetyDefinition([NotNull] IReadOnlyList<IGoalDescription> safety)
        {
            if(ReferenceEquals(safety, null)) throw new ArgumentNullException("safety", "The value of 'requirements' cannot be null.");
            Safety = safety;
        }
    }
}
