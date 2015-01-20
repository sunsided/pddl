using System;
using System.Linq;
using JetBrains.Annotations;

namespace PDDL.Tokenizer.Tokens
{
    /// <summary>
    /// Class Letters. This class cannot be inherited.
    /// </summary>
    sealed class Letters : Token
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [NotNull]
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Letters" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> was <see langword="null"/></exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> was empty or whitespace-only or contained invalid characters</exception>
        public Letters([NotNull] string value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException("value", "value was null");
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("value must not be empty or whitespace only", "value");
            if (!IsValid(value)) throw new ArgumentException("value contained invalid characters", "value");
            Value = value;
        }

        /// <summary>
        /// Determines whether the specified value is valid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see langword="true" /> if the specified value is valid; otherwise, <see langword="false" />.</returns>
        [Pure]
        public static bool IsValid([CanBeNull] string value)
        {
            if (String.IsNullOrWhiteSpace(value)) return false;

            // first character must be a letter
            // following characters may be either letter, digit, hyphen or underscore
            return value.All(Char.IsLetter);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Value;
        }
    }
}
