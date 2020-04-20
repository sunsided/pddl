namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface IPrecondition
    /// </summary>
    public interface IPrecondition
    {
        /// <summary>
        /// Gets the preconditions.
        /// </summary>
        /// <value>The preconditions.</value>
        IGoalDescription Preconditions { get; }
    }
}
