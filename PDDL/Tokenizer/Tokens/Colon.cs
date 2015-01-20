namespace PDDL.Tokenizer.Tokens
{
    /// <summary>
    /// Class Colon. This class cannot be inherited.
    /// </summary>
    sealed class Colon : Token
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Colon"/> class.
        /// </summary>
        public Colon()
        {
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return ":";
        }
    }
}
