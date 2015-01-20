using JetBrains.Annotations;

namespace PDDL.Symbols.Keywords
{
    /// <summary>
    /// Class DefineKeyword.
    /// </summary>
    sealed class DefineKeyword : Keyword
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Keyword" /> class.
        /// </summary>
        public DefineKeyword()
            : base("define")
        {
        }

        /// <summary>
        /// Determines whether the specified value is valid.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see langword="true" /> if the specified value is valid; otherwise, <see langword="false" />.</returns>
        public static bool IsValid([CanBeNull] string value)
        {
            return Equals(value, "define");
        }
    }
}
