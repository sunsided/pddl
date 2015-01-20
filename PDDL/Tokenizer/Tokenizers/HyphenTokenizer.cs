using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class HyphenTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class HyphenTokenizer : SpecificSymbolTokenizer<Hyphen>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HyphenTokenizer"/> class.
        /// </summary>
        public HyphenTokenizer() : base('-')
        { }
    }
}
