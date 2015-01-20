using System;
using System.IO;
using JetBrains.Annotations;

namespace PDDL.Tokenizer
{
    /// <summary>
    /// Class ReaderExtensions.
    /// </summary>
    static class ReaderExtensions
    {
        /// <summary>
        /// Determines whether the specified reader has data.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns><see langword="true" /> if the specified reader has data; otherwise, <see langword="false" />.</returns>
        /// <exception cref="ArgumentNullException">The value of 'reader' cannot be null. </exception>
        /// <exception cref="IOException">An I/O error occurs. </exception>
        public static bool HasData([NotNull] this TextReader reader)
        {
            if (ReferenceEquals(reader, null)) throw new ArgumentNullException("reader", "The reader was null.");
            return reader.Peek() >= 0;
        }
    }
}
