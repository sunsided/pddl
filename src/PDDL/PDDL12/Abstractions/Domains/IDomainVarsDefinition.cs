using System.Collections.Generic;
using PDDL.PDDL12.Abstractions.Variables;

namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainVarsDefinition
    /// </summary>
    public interface IDomainVarsDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the safety constraints.
        /// </summary>
        /// <value>The safety constraints.</value>
        IReadOnlyList<IDomainVariable> Variables { get; }
    }
}
