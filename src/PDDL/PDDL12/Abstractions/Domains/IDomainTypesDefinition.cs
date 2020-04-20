using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainTypesDefinition
    /// </summary>
    public interface IDomainTypesDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the type definitions.
        /// </summary>
        /// <remarks>Uses the <c>:typing</c> requirement.</remarks>
        /// <value>The types.</value>
        IReadOnlyList<IType> Types { get; }
    }
}
