namespace PDDL.PDDL12.Abstractions.Values
{
    /// <summary>
    /// Interface IDynamicValue
    /// </summary>
    public interface IDynamicValue : IValue
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        dynamic Value { get; }
    }
}
