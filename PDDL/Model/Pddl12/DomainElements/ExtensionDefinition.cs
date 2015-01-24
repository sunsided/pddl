using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.DomainElements
{
    /// <summary>
    /// Class ExtensionDefinition. This class cannot be inherited.
    /// </summary>
    public sealed class ExtensionDefinition : IDomainExtensionDefinition
    {
        /// <summary>
        /// Gets the name definitions.
        /// </summary>
        /// <value>The names.</value>
        [NotNull]
        public IReadOnlyList<IName> Names { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtensionDefinition"/> class.
        /// </summary>
        /// <param name="names">The names.</param>
        /// <exception cref="ArgumentNullException">The value of 'names' cannot be null. </exception>
        public ExtensionDefinition([NotNull] IReadOnlyList<IName> names)
        {
            if (ReferenceEquals(names, null)) throw new ArgumentNullException("names", "The value cannot be null.");
            Names = names;
        }
    }
}
