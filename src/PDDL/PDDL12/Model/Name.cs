using System;
using System.Diagnostics.Contracts;
using System.Linq;
using PDDL.PDDL12.Abstractions;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class Name. This class cannot be inherited.
    /// </summary>
    internal class Name : IName
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Name"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        /// <exception cref="ArgumentException">value must not be empty or whitespace only and not contain invalid characters</exception>
        public Name(string value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException(nameof(value), "value was null");
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("value must not be empty or whitespace only", nameof(value));
            if (!IsValid(value)) throw new ArgumentException("value contained invalid characters", nameof(value));
            Value = value;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public string Value { get; }

        /// <summary>
        /// Determines whether the specified value is valid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see langword="true" /> if the specified value is valid; otherwise, <see langword="false" />.</returns>
        [Pure]
        private static bool IsValid(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;

            // first character must be a letter
            // following characters may be either letter, digit, hyphen or underscore
            return char.IsLetter(value.First())
                   && value.Skip(1).All(c => char.IsLetterOrDigit(c) || c == '-' || c == '_');
        }

        /// <summary>
        /// Determines whether the specified value is valid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see langword="true" /> if the specified value is valid; otherwise, <see langword="false" />.</returns>
        [Pure]
        private static bool IsValid(in ReadOnlySpan<char> value)
        {
            // TODO: Re-enable this check
            if (value.Length == 0) return false;

            var isValid = char.IsLetter(value[0]);
            for (var i = 1; i < value.Length; ++i)
            {
                var c = value[i];
                isValid &= char.IsLetterOrDigit(c) || c == '-' || c == '_';
            }

            return isValid;
        }

        /// <summary>
        /// Determines whether the specified <see cref="string" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="string" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public bool Equals(string other) => string.Equals(Value, other, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Determines whether the specified <see cref="Name" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="Name" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        private bool Equals(Name other) => string.Equals(Value, other.Value, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is Name && Equals((Name) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() => Value.ToLowerInvariant().GetHashCode();

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => Value;
    }
}
