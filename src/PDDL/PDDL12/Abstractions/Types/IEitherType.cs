using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Types
{
    /// <summary>
    /// Interface IEitherType
    /// <para>
    ///     Describes a set of allowed types within a <see cref="IDomain"/>,
    ///     given the <c>:typing</c> requirement.
    /// </para>
    /// </summary>
    public interface IEitherType : IType
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        IReadOnlyList<IType> Types { get; }
    }
}
