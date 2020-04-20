namespace PDDL.PDDL12.Abstractions.Goals
{
    /// <summary>
    /// Interface ILiteralGoalDescription
    /// </summary>
    public interface ILiteralGoalDescription : IGoalDescription
    {
        /// <summary>
        /// Gets the literal.
        /// </summary>
        /// <value>The literal.</value>
        ILiteral<ITerm> Literal { get; }
    }
}
