﻿using System.IO;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class ColonTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class ColonTokenizer : TokenizerBase
    {
        /// <summary>
        /// Processes the stream for a token.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="IOException">An I/O error occurs.</exception>
        protected override bool TryReadInternal(TextReader input, out Token token)
        {
            token = default(Letters);

            if (input.ReadAndChokeIf(':'))
            {
                token = new Colon();
            }

            return (token != null);
        }
    }
}
