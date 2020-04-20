using PDDL.PDDL12.Abstractions.Problems;

namespace PDDL.PDDL12.Abstractions.Goals
{
    /// <summary>
    /// Interface IProblemGoalDefinition
    /// </summary>
    public interface IProblemGoalDefinition : IProblemDefinitionElement
    {
        /// <summary>
        /// Gets the goal.
        /// </summary>
        /// <value>The goal.</value>
        IGoalDescription Goal { get; }
    }
}
