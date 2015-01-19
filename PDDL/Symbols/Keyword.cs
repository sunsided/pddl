using System;
using JetBrains.Annotations;

namespace PDDL.Symbols
{
    /// <summary>
    /// Class Keyword.
    /// </summary>
    abstract class Keyword : Symbol
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [NotNull]
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Keyword" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> was <see langword="null"/></exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> was empty or whitespace-only</exception>
        protected Keyword([NotNull] string value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException("value", "value was null");
            if (String.IsNullOrWhiteSpace(value)) throw new ArgumentException("value must not be empty or whitespace only", "value");
            Value = value;
        }
    }
}
