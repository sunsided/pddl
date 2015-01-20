﻿using System;
using System.IO;
using System.Text;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class DigitsTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class DigitsTokenizer : TokenizerBase
    {
        /// <summary>
        /// Processes the stream for a token.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        protected override bool TryReadInternal(TextReader input, out Token token)
        {
            token = default(Letters);

            // attempt to read the opening parenthesis
            var sb = new StringBuilder();
            while (Char.IsDigit((char)input.Peek()))
            {
                sb.Append((char)input.Read());
            }

            // create the token, if possible
            if (sb.Length > 0) token = new Digits(sb.ToString());

            return (token != null);
        }
    }
}
