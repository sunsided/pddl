using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IType
    /// <para>
    ///     Describes a type within a <see cref="IDomain"/>,
    ///     given the <c>:typing</c> requirement.
    /// </para>
    /// </summary>
    public interface IType
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [NotNull]
        string Value { get; }
    }
}
