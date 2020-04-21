using System;

namespace PDDL.PDDL12.Abstractions.Values
{
    /// <summary>
    /// Interface IDecimalValue
    /// </summary>
    public interface IDecimalValue : IValue, IEquatable<IDecimalValue>, IEquatable<decimal>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        decimal Value { get; }
    }
}
