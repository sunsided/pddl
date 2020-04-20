namespace PDDL.Model.PDDL12.Goals
{
    /// <summary>
    /// Class GoalBase.
    /// </summary>
    public abstract class GoalBase : IGoalDescription
    {
        /// <summary>
        /// Gets the kind of goal.
        /// </summary>
        /// <value>The kind.</value>
        public abstract GoalKind Kind { get; }
    }
}
