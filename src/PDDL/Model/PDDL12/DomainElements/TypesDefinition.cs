using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class TypesDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class TypesDefinition : IDomainTypesDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypesDefinition"/> class.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <exception cref="ArgumentNullException">The value of 'types' cannot be null. </exception>
        public TypesDefinition([NotNull] IReadOnlyList<IType> types)
        {
            Types = types ?? throw new ArgumentNullException(nameof(types), "The value cannot be null.");
        }

        /// <summary>
        /// Gets the type definitions.
        /// </summary>
        /// <remarks>Uses the <c>:typing</c> requirement.</remarks>
        /// <value>The types.</value>
        public IReadOnlyList<IType> Types { get; }
    }
}
