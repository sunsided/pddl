using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class RequirementsDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class RequirementsDefinition : IDomainRequireDefinition, IProblemRequireDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementsDefinition"/> class.
        /// </summary>
        /// <param name="requirements">The requirements.</param>
        /// <exception cref="ArgumentNullException">The value of 'requirements' cannot be null. </exception>
        public RequirementsDefinition([NotNull] IReadOnlyList<IRequirement> requirements)
        {
            Requirements = requirements ?? throw new ArgumentNullException(nameof(requirements), "The value of 'requirements' cannot be null.");
        }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        public IReadOnlyList<IRequirement> Requirements { get; }
    }
}
