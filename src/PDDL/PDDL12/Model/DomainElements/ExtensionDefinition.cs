using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Domains;

namespace PDDL.PDDL12.Model.DomainElements
{
    /// <summary>
    /// Class ExtensionDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ExtensionDefinition : IDomainExtensionDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionDefinition"/> class.
        /// </summary>
        /// <param name="names">The names.</param>
        /// <exception cref="ArgumentNullException">The value of 'names' cannot be null. </exception>
        public ExtensionDefinition(IReadOnlyList<IName> names)
        {
            Names = names ?? throw new ArgumentNullException(nameof(names), "The value cannot be null.");
        }

        /// <summary>
        /// Gets the name definitions.
        /// </summary>
        /// <value>The names.</value>
        public IReadOnlyList<IName> Names { get; }
    }
}
