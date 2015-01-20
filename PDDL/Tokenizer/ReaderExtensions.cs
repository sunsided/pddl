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

        /// <summary>
        /// Tests if the next character equals the specified input and takes it from the stream,
        /// otherwise does not touch the stream and returns <see langword="false"/>
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="is">The is.</param>
        /// <returns><see langword="true" /> if the specified reader has data; otherwise, <see langword="false" />.</returns>
        /// <exception cref="System.ArgumentNullException">reader;The reader was null.</exception>
        /// <exception cref="ArgumentNullException">The value of 'reader' cannot be null.</exception>
        /// <exception cref="IOException">An I/O error occurs.</exception>
        public static bool ReadAndChokeIf([NotNull] this TextReader reader, char @is)
        {
            if (ReferenceEquals(reader, null)) throw new ArgumentNullException("reader", "The reader was null.");
            if (reader.Peek() == @is)
            {
                reader.Read();
                return true;
            }
            return false;
        }
    }
}
