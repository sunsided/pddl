using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Domains;

namespace PDDL.PDDL12.Model.DomainElements
{
    /// <summary>
    /// Class SafetyDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class SafetyDefinition : IDomainSafetyDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SafetyDefinition"/> class.
        /// </summary>
        /// <param name="safety">The safety.</param>
        /// <exception cref="ArgumentNullException">The value of 'safety' cannot be null. </exception>
        public SafetyDefinition(IReadOnlyList<IGoalDescription> safety)
        {
            Safety = safety ?? throw new ArgumentNullException(nameof(safety), "The value of 'requirements' cannot be null.");
        }

        /// <summary>
        /// Gets the safety constraints.
        /// </summary>
        /// <value>The safety constraints.</value>
        public IReadOnlyList<IGoalDescription> Safety { get; }
    }
}
