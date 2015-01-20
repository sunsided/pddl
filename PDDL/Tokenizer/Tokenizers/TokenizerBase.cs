using System;
using System.IO;
using JetBrains.Annotations;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class Tokenizer.
    /// </summary>
    internal abstract class TokenizerBase
    {
        /// <summary>
        /// Tries to read names.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">input;The reader was null.</exception>
        /// <exception cref="IOException">An I/O error occurs. </exception>
        public virtual bool TryRead([NotNull] TextReader input, [CanBeNull] out Token token)
        {
            if (ReferenceEquals(input, null)) throw new ArgumentNullException("input", "The reader was null.");
            if (!input.HasData())
            {
                token = default(Token);
                return false;
            }

            return TryReadInternal(input, out token);
        }

        /// <summary>
        /// Processes the stream for a token.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="token">The token.</param>
        /// <returns><see langword="true" /> if the token could be read, <see langword="false" /> otherwise.</returns>
        /// <exception cref="IOException">An I/O error occurs. </exception>
        protected abstract bool TryReadInternal([NotNull] TextReader input, [CanBeNull] out Token token);
    }
}
