using System;

namespace PDDL.Symbols
{
    /// <summary>
    /// Class Whitespace.
    /// </summary>
    sealed class Whitespace : Symbol
    {
        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>The length.</value>
        public int Length { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Whitespace" /> class.
        /// </summary>
        /// <param name="length">The length.</param>
        /// <exception cref="System.ArgumentOutOfRangeException"><paramref name="length"/> must be positive</exception>
        public Whitespace(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException("length", length, "length must be positive");
            Length = length;
        }
    }
}
