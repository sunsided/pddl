using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
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
        [NotNull]
        string Value { get; }
    }
}
