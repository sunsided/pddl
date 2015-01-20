using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
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
        /// <exception cref="ArgumentException">An invalid character was encountered. </exception>
        [NotNull]
        public IEnumerable<Token> Tokenize([NotNull] TextReader input)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            while (input.HasData())
            {
                Token token;
                if (TryReadWhitespace(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadComment(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadParenthesis(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadColon(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadLiteral(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadLetters(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadHyphen(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadUnderscore(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadQuestionMark(input, out token))
                {
                    yield return token;
                    continue;
                }
                if (TryReadDigits(input, out token))
                {
                    yield return token;
                    continue;
                }

                // if we reach this state, then an invalid character was encountered int he stream
                if (input.Peek() >= 0)
                {
                    throw new ArgumentException("Encountered an invalid character: '" + (char) input.Read() + "'");
                }
                break;
            }
        }

        /// <summary>
        /// Tries to read names.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadLiteral([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

            var sb = new StringBuilder();
            // the first character has to be a letter, so if it is not,
            // skip the rest.
            var value = input.Peek();
            if (value <= 0 || !Char.IsLetter((char) value)) return false;
            
            // now consume, as long as there are any letters, digits, hyphens or underscores
            while (value >= 0)
            {
                if (Char.IsLetterOrDigit((char) value) || (char) value == '_' || (char) value == '-')
                {
                    sb.Append((char) input.Read());
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

        /// <summary>
        /// Tries to read letters.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadLetters([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

            // attempt to read the opening parenthesis
            var sb = new StringBuilder();
            while (Char.IsLetter((char)input.Peek()))
            {
                sb.Append((char)input.Read());
            }

            // create the token, if possible
            if (sb.Length > 0) token = new Letters(sb.ToString());

            return (token != null);
        }

        /// <summary>
        /// Tries to read digits.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadDigits([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

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

        /// <summary>
        /// Tries to read a colon.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadColon([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

            if (input.ReadAndChokeIf(':'))
            {
                token = new Colon();
            }

            return (token != null);
        }
        
        /// <summary>
        /// Tries to read a hyphen.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadHyphen([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

            if (input.ReadAndChokeIf('-'))
            {
                token = new Hyphen();
            }

            return (token != null);
        }

        /// <summary>
        /// Tries to read an underscore.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadUnderscore([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

            if (input.ReadAndChokeIf('_'))
            {
                token = new Underscore();
            }

            return (token != null);
        }

        /// <summary>
        /// Tries to read a question mark.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadQuestionMark([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

            if (input.ReadAndChokeIf('?'))
            {
                token = new QuestionMark();
            }

            return (token != null);
        }


        /// <summary>
        /// Tries to read a parenthesis.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadParenthesis([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

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

        /// <summary>
        /// Tries to read whitespace.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadWhitespace([NotNull] TextReader input, out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");

            token = default(Comment);

            // attempt to eat as much whitespace as possible
            var count = 0;
            while (input.HasData() && Char.IsWhiteSpace((char) input.Peek()))
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

        /// <summary>
        /// Tries to read a comment.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        private static bool TryReadComment([NotNull] TextReader input, out Token token)
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
