using System;

namespace PDDL.PDDL12.Abstractions
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
        string Value { get; }
    }
}
