namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface ITyped
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITyped<out T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        T Value { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        IType Type { get; }
    }
}
