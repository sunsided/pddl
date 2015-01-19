using System;
using System.Collections.Generic;
using System.IO;
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
        [NotNull]
        public IEnumerable<Token> Tokenize([NotNull] TextReader input)
        {
            throw new NotImplementedException();
        }
    }
}
