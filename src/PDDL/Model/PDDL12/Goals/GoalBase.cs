namespace PDDL.Model.PDDL12.Goals
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
