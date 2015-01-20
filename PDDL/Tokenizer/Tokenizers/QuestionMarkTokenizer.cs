using PDDL.Tokenizer.Tokens;

namespace PDDL.Tokenizer.Tokenizers
{
    /// <summary>
    /// Class QuestionMarkTokenizer. This class cannot be inherited.
    /// </summary>
    sealed class QuestionMarkTokenizer : SpecificSymbolTokenizer<QuestionMark>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionMarkTokenizer"/> class.
        /// </summary>
        public QuestionMarkTokenizer() : base('?')
        { }
    }
}
