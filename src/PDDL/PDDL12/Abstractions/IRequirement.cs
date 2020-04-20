namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface IRequirement
    /// <para>
    ///     Names a requirement for a <see cref="IDomain"/>.
    /// </para>
    /// </summary>
    public interface IRequirement
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        string Value { get; }
    }
}
