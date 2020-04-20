using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Goals
{
    /// <summary>
    /// Interface IConjunctionGoalDescription
    /// <para>
    ///     Combines multiple goals using an <c>and</c> relationship.
    /// </para>
    /// </summary>
    public interface IConjunctionGoalDescription : IGoalDescription
    {
        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <value>The goals.</value>
        IReadOnlyList<IGoalDescription> Goals { get; }
    }
}
