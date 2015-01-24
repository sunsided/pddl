namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IValueBinding
    /// </summary>
    public interface IValue
    {
    }

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
