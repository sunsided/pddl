using System;
using System.IO;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class WhitespaceTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class WhitespaceTokenizer : TokenizerBase
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

            // attempt to eat as much whitespace as possible
            var count = 0;
            while (input.HasData() && Char.IsWhiteSpace((char)input.Peek()))
            {
                // choke the whitespace
                input.Read();
                ++count;
            }

            // if we read anything, export the whitespace token
            var readAnything = count > 0;
            if (readAnything)
            {
                token = new Whitespace(count);
            }
            return readAnything;
        }
    }
}
