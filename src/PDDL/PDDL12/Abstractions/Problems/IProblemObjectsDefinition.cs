using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Problems
{
    /// <summary>
    /// Interface IProblemObjectsDefinition
    /// </summary>
    public interface IProblemObjectsDefinition : IProblemDefinitionElement
    {
        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <value>The objects.</value>
        IReadOnlyList<IObject> Objects { get; }
    }
}
