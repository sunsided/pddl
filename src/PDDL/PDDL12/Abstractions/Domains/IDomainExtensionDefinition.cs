using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainExtensionDefinition
    /// </summary>
    public interface IDomainExtensionDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <value>The names.</value>
        IReadOnlyList<IName> Names { get; }
    }
}
