using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer
{
    /// <summary>
    /// Interface IPddlTokenizer
    /// </summary>
    interface IPddlTokenizer
    {
        /// <summary>
        /// Tokenizes the text using the given input stream reader.
        /// </summary>
        /// <param name="input">The input stream reder.</param>
        /// <returns>A sequence of tokens.</returns>
        /// <exception cref="ArgumentNullException">The value of 'input' cannot be null. </exception>
        /// <exception cref="IOException">An I/O error occurs. </exception>
        /// <exception cref="ArgumentException">An invalid character was encountered. </exception>
        IEnumerable<Token> Tokenize([NotNull] TextReader input);
    }
}