using System;
using System.Collections.Generic;
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
    }

    /// <summary>
    /// Interface IPlainType
    /// <para>
    ///     Describes a specific type within a <see cref="IDomain"/>,
    ///     given the <c>:typing</c> requirement.
    /// </para>
    /// </summary>
    public interface IPlainType : IType
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        IName Name { get; }
    }

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
        [NotNull]
        IReadOnlyList<IType> Types { get; }
    }

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
        [NotNull]
        IType Type { get; }
    }
}
