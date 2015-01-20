using System;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using PDDL.Tokenizer.Tokenizers;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer
{
    /// <summary>
    /// Class Pddl12Tokenizer.
    /// <para>
    /// Implements a tokenizer for the PDDL 1.2 syntax.
    /// </para>
    /// </summary>
    sealed class Pddl12Tokenizer
    {
        /// <summary>
        /// The tokenizers to be used
        /// </summary>
        [NotNull]
        private readonly TokenizerBase[] _tokenizers =
        {
            // whitespaces are most likely
            new WhitespaceTokenizer(),
            // followed by literals of any kind
            new LiteralTokenizer(),
            // also parentheses are quite common
            new ParenthesisTokenizer(),
            // since variables appear often, they follow next
            new QuestionMarkTokenizer(),
            // sometimes there are even colons
            new ColonTokenizer(),
            // and, of course, comments
            new CommentTokenizer(),
            // hypens may appear as part of :typed
            new HyphenTokenizer(),

            // we may need these later
            new LettersTokenizer(), 
            new DigitsTokenizer(), 
            new UnderscoreTokenizer(),
        };

        /// <summary>
        /// Tokenizes the text using the given input stream reader.
        /// </summary>
        /// <param name="input">The input stream reder.</param>
        /// <returns>A sequence of tokens.</returns>
        /// <exception cref="ArgumentNullException">The value of 'input' cannot be null. </exception>
        /// <exception cref="IOException">An I/O error occurs. </exception>
        /// <exception cref="ArgumentException">An invalid character was encountered. </exception>
        [NotNull]
        public IEnumerable<Token> Tokenize([NotNull] TextReader input)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            var tokenizers = _tokenizers;
            var count = tokenizers.Length;

            while (input.HasData())
            {
                // iterate over all tokenizers
                bool success = false;
                for (int i = 0; i < count; ++i)
                {
                    var tokenizer = tokenizers[i];
                    
                    // attempt to match. if it does not succeed,
                    // skip to the next tokenizer.
                    Token token;
                    if (!tokenizer.TryRead(input, out token)) continue;

                    // if it succeeded, yield the token and continue
                    yield return token;
                    success = true;
                }

                // if at least one tokenizer matched, continue
                if (success) continue;

                // if we reach this state, then an invalid character was encountered int he stream
                if (input.Peek() >= 0)
                {
                    throw new ArgumentException("Encountered an invalid character: '" + (char) input.Read() + "'");
                }
                break;
            }
        }
    }
}
