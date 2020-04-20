using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainTimelessDefinition
    /// </summary>
    public interface IDomainTimelessDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the timeless definitions.
        /// </summary>
        /// <value>The timeless.</value>
        IReadOnlyList<ILiteral<IName>> Timeless { get; }
    }
}
