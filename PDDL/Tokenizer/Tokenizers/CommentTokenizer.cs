using System.Diagnostics;
using System.IO;
using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class CommentTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class CommentTokenizer : TokenizerBase
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
