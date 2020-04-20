using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Problems
{
    /// <summary>
    /// Interface IProblemInitialStateDefinition
    /// </summary>
    public interface IProblemInitialStateDefinition : IProblemDefinitionElement
    {
        /// <summary>
        /// Gets the initial state.
        /// </summary>
        /// <value>The initial state.</value>
        IReadOnlyList<ILiteral<IName>> State { get; }
    }
}
