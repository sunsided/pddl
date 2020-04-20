using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainRequireDefinition
    /// </summary>
    public interface IDomainRequireDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        IReadOnlyList<IRequirement> Requirements { get; }
    }
}
