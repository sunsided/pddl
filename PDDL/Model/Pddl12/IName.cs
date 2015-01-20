using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IName
    /// <para>
    ///     Contains the name of an object, domain, problem, etc.
    /// </para>
    /// </summary>
    public interface IName : ITerm, IEquatable<string>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [NotNull]
        string Value { get; }
    }
}
