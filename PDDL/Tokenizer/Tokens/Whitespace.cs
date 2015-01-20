using System;

namespace PDDL.Tokenizer.Tokens
{
    /// <summary>
    /// Class Whitespace.
    /// </summary>
    sealed class Whitespace : Token
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

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Empty.PadLeft(Length);
        }
    }
}
