using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class UnderscoreTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class UnderscoreTokenizer : SpecificSymbolTokenizer<Underscore>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnderscoreTokenizer"/> class.
        /// </summary>
        public UnderscoreTokenizer() : base('_')
        { }
    }
}
