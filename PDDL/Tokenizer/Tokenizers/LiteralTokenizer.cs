using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class LiteralTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class LiteralTokenizer : TokenizerBase
    {
        /// <summary>
        /// Processes the stream for a token.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        protected override bool TryReadInternal(TextReader input, out Token token)
        {
            token = default(Literal);

            var sb = new StringBuilder();
            // the first character has to be a letter, so if it is not,
            // skip the rest.
            var value = input.Peek();
            if (value <= 0 || !Char.IsLetter((char)value)) return false;

            // now consume, as long as there are any letters, digits, hyphens or underscores
            while (value >= 0)
            {
                if (Char.IsLetterOrDigit((char)value) || (char)value == '_' || (char)value == '-')
                {
                    sb.Append((char)input.Read());
                }
                else
                {
                    // stop if there is a mismatch
                    break;
                }

                // peek forward
                value = input.Peek();
            }

            // create the token, if possible
            Debug.Assert(sb.Length > 0, "sb.Length > 0");
            token = new Literal(sb.ToString());
            return true;
        }
    }
}
