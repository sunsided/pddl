using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using JetBrains.Annotations;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer
{
    /// <summary>
    /// Class PddlTokenizer.
    /// <para>
    /// Implements a tokenizer for the PDDL 1.2 syntax.
    /// </para>
    /// </summary>
    class PddlTokenizer
    {
        /// <summary>
        /// Tokenizes the text using the given input stream reader.
        /// </summary>
        /// <param name="input">The input stream reder.</param>
        /// <returns>A sequence of tokens.</returns>
        /// <exception cref="ArgumentNullException">The value of 'input' cannot be null. </exception>
        /// <exception cref="IOException">An I/O error occurs. </exception>
        [NotNull]
        public IEnumerable<Token> Tokenize([NotNull] TextReader input)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            while (input.HasData())
            {
                Comment token;
                if (TryReadComment(input, out token)) yield return token;
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Tries to read a comment.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadComment([NotNull] TextReader input, out Comment token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);
            if (!input.HasData()) return false;

            // check for the semicolon
            var c = (char)input.Peek();
            if (!Equals(c, ';')) return false;

            // if the semicolon was found, read to the end of the line
            var comment = input.ReadLine();
            Debug.Assert(comment != null, "comment != null");
            token = new Comment(comment);
            return true;
        }
    }
}
