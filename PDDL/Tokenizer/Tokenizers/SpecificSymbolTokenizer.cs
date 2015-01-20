using System.IO;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class SpecificSymbolTokenizer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    abstract class SpecificSymbolTokenizer<T> : TokenizerBase
        where T : Token, new()
    {
        /// <summary>
        /// The symbol to match
        /// </summary>
        private readonly char _symbol;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpecificSymbolTokenizer{T}"/> class.
        /// </summary>
        /// <param name="symbol">The symbol.</param>
        protected SpecificSymbolTokenizer(char symbol)
        {
            _symbol = symbol;
        }

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

            if (input.ReadAndChokeIf(_symbol))
            {
                token = new T();
            }

            return (token != null);
        }
    }
}
