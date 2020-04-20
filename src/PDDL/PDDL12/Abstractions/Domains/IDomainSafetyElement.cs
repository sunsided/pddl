using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainSafetyDefinition
    /// </summary>
    public interface IDomainSafetyDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the safety constraints.
        /// </summary>
        /// <value>The safety constraints.</value>
        IReadOnlyList<IGoalDescription> Safety { get; }
    }
}
