namespace PDDL.Tokenizer.Tokens
{
    /// <summary>
    /// Class Parenthesis. This class cannot be inherited.
    /// </summary>
    sealed class Parenthesis : Token
    {
        /// <summary>
        /// Enum Type
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// Opening parenthesis
            /// </summary>
            Open,

            /// <summary>
            /// Closing parenthesis
            /// </summary>
            Close
        }

        /// <summary>
        /// Gets the parenthesis type.
        /// </summary>
        /// <value>The direction.</value>
        public Type Direction { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parenthesis"/> class.
        /// </summary>
        /// <param name="direction">The direction.</param>
        public Parenthesis(Type direction)
        {
            Direction = direction;
        }
    }
}
