namespace PDDL.Tokenizer.Tokens
{
    /// <summary>
    /// Class Underscore. This class cannot be inherited.
    /// </summary>
    sealed class Underscore : Token
    {
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "_";
        }
    }
}
