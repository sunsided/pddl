using System;
using JetBrains.Annotations;

namespace PDDL.Tokenizer.Tokens
{
    /// <summary>
    /// Class Comment.
    /// </summary>
    sealed class Comment : Token
    {
        /// <summary>
        /// Gets the comment.
        /// </summary>
        /// <value>The comment.</value>
        [NotNull]
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Comment" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> was <see langword="null"/></exception>
        public Comment([NotNull] string value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException("value", "value was null");
            Value = value;
        }
    }
}
