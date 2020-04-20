namespace PDDL.PDDL12.Abstractions.Values
{
    /// <summary>
    /// Interface IDecimalValue
    /// </summary>
    public interface IDecimalValue : IValue
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        decimal Value { get; }
    }
}
