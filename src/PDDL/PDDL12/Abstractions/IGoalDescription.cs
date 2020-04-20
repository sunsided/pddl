using PDDL.PDDL12.Abstractions.Goals;

namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface IGoalDescription
    /// <para>
    ///     A goal description is used to specify the desired goals in a planning problem and also
    ///     the preconditions for an action.
    /// </para>
    /// </summary>
    public interface IGoalDescription
    {
        /// <summary>
        /// Gets the kind of goal.
        /// </summary>
        /// <value>The kind.</value>
        GoalKind Kind { get; }
    }
}
