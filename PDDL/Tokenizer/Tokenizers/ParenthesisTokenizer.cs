using System.IO;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class ParenthesisTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class ParenthesisTokenizer : TokenizerBase
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

            // attempt to read the opening parenthesis
            if (input.ReadAndChokeIf('('))
            {
                token = new Parenthesis(Parenthesis.Type.Open);
            }

            // attempt to read the closing parenthesis
            if (input.ReadAndChokeIf(')'))
            {
                token = new Parenthesis(Parenthesis.Type.Close);
            }

            return (token != null);
        }
    }
}
