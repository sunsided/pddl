using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainConstantsDefinition
    /// </summary>
    public interface IDomainConstantsDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the constants definitions.
        /// </summary>
        /// <value>The constants.</value>
        IReadOnlyList<IConstant> Constants { get; }
    }
}
