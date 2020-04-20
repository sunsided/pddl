namespace PDDL.PDDL12.Abstractions.Goals
{
    /// <summary>
    /// Interface IAtomicGoalDescription
    /// </summary>
    public interface IAtomicGoalDescription : IGoalDescription
    {
        /// <summary>
        /// Gets the condition.
        /// </summary>
        /// <value>The condition.</value>
        IAtomicFormula<ITerm> Condition { get; }
    }
}
