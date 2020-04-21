﻿using System.Globalization;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Values;

namespace PDDL.PDDL12.Model.Value
{
    /// <summary>
    /// Class DecimalValue. This class cannot be inherited.
    /// </summary>
    internal sealed class DecimalValue : IDecimalValue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalValue"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public DecimalValue(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; }

        /// <summary>
        /// Determines whether the specified <see cref="DecimalValue" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="DecimalValue" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public bool Equals(decimal other) => Value.Equals(other);

        /// <summary>
        /// Determines whether the specified <see cref="DecimalValue" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="DecimalValue" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public bool Equals(IDecimalValue other) => Equals(other.Value);

        /// <summary>
        /// Determines whether the specified <see cref="IValue" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="DecimalValue" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public bool Equals(IValue other) => Equals((object) other);

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is IDecimalValue value && Equals(value);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}
