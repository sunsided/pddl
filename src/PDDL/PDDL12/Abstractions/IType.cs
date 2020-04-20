using PDDL.PDDL12.Abstractions.Types;

namespace PDDL.PDDL12.Abstractions
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
        /// Gets the kind of this type.
        /// </summary>
        TypeKind Kind { get; }
    }
}
