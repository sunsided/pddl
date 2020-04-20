using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Problems
{
    /// <summary>
    /// Interface IProblemRequireDefinition
    /// </summary>
    public interface IProblemRequireDefinition : IProblemDefinitionElement
    {
        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        IReadOnlyList<IRequirement> Requirements { get; }
    }
}
