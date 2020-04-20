namespace PDDL.PDDL12.Abstractions.Types
{
    /// <summary>
    /// Interface IFluentType
    /// <para>
    ///     Describes a fluent type within a <see cref="IDomain"/>,
    ///     given the <c>:typing</c> requirement.
    /// </para>
    /// </summary>
    public interface IFluentType : IType
    {
        /// <summary>
        /// Gets the fluent type.
        /// </summary>
        /// <value>The fluent type.</value>
        IType Type { get; }
    }
}
