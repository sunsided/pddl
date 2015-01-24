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
    }
}
