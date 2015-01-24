using JetBrains.Annotations;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class Keywords.
    /// </summary>
    internal static class Keywords
    {
        /// <summary>
        /// The keyword <c>not</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Not =
            Parse.String("not").Text().Token();

        /// <summary>
        /// The keyword <c>and</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> And =
            Parse.String("and").Text().Token();

        /// <summary>
        /// The keyword <c>:precondition</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Precondition =
            Parse.String(":precondition").Text().Token();

        /// <summary>
        /// The keyword <c>:parameters</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Parameters =
            Parse.String(":parameters").Text().Token();

        /// <summary>
        /// The keyword <c>:effect</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Effect =
            Parse.String(":effect").Text().Token();

        /// <summary>
        /// The keyword <c>:action</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Action =
            Parse.String(":action").Text().Token();
    }
}
