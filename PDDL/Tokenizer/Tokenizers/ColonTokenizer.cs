using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class ColonTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class ColonTokenizer : SpecificSymbolTokenizer<Colon>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColonTokenizer"/> class.
        /// </summary>
        public ColonTokenizer() : base(':')
        {}
    }
}
