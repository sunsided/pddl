namespace PDDL.PDDL12.Abstractions.Types
{
    /// <summary>
    /// Interface IPlainType
    /// <para>
    ///     Describes a specific type within a <see cref="IDomain"/>,
    ///     given the <c>:typing</c> requirement.
    /// </para>
    /// </summary>
    public interface ICustomType : IType
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        IName Name { get; }

        /// <summary>
        /// Gets or sets the parent type.
        /// </summary>
        /// <value>The parent type.</value>
        IType Parent { get; }
    }
}
