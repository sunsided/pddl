using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
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
        public ExtensionDefinition([NotNull] IReadOnlyList<IName> names)
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
