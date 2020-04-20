using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Goals;

namespace PDDL.PDDL12.Model.Goals
{
    /// <summary>
    /// Class GoalBase.
    /// </summary>
    internal abstract class GoalBase : IGoalDescription
    {
        /// <summary>
        /// Gets the kind of goal.
        /// </summary>
        /// <value>The kind.</value>
        public abstract GoalKind Kind { get; }
    }
}
