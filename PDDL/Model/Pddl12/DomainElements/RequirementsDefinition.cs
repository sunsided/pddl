﻿using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.DomainElements
{
    /// <summary>
    /// Class RequirementsDefinition. This class cannot be inherited.
    /// </summary>
    public sealed class RequirementsDefinition : IDomainRequireDefinition
    {
        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        [NotNull]
        public IReadOnlyList<IRequirement> Requirements { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementsDefinition"/> class.
        /// </summary>
        /// <param name="requirements">The requirements.</param>
        /// <exception cref="ArgumentNullException">The value of 'requirements' cannot be null. </exception>
        public RequirementsDefinition([NotNull] IReadOnlyList<IRequirement> requirements)
        {
            if(ReferenceEquals(requirements, null)) throw new ArgumentNullException("requirements", "The value of 'requirements' cannot be null.");
            Requirements = requirements;
        }
    }
}