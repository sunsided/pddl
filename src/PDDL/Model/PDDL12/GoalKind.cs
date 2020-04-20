namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Enum GoalKind
    /// </summary>
    public enum GoalKind
    {
        /// <summary>
        /// The goal contains only of ground atoms.
        /// </summary>
        Atomic,

        /// <summary>
        /// The goal contains of literals, which can either be
        /// a positive or negative ground atom.
        /// </summary>
        Literal,

        /// <summary>
        /// The goal description is a conjunction of multiple subgoals.
        /// </summary>
        Conjunction,

        /// <summary>
        /// There is no condition.
        /// </summary>
        None
    }
}
