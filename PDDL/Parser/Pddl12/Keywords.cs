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

        /// <summary>
        /// The keyword <c>:vars</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Vars =
            Parse.String(":vars").Text().Token();

        /// <summary>
        /// The keyword <c>:axiom</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Axiom =
            Parse.String(":axiom").Text().Token();

        /// <summary>
        /// The keyword <c>:context</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Context =
            Parse.String(":context").Text().Token();

        /// <summary>
        /// The keyword <c>:implies</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Implies =
            Parse.String(":implies").Text().Token();

        /// <summary>
        /// The keyword <c>define</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Define =
            Parse.String("define").Text().Token();

        /// <summary>
        /// The keyword <c>domain</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Domain =
            Parse.String("domain").Text().Token();

        /// <summary>
        /// The keyword <c>:predicates</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Predicates =
            Parse.String(":predicates").Text().Token();

        /// <summary>
        /// The keyword <c>:extends</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Extends =
            Parse.String(":extends").Text().Token();

        /// <summary>
        /// The keyword <c>:requirements</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Requirements =
            Parse.String(":requirements").Text().Token();

        /// <summary>
        /// The keyword <c>:types</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Types =
            Parse.String(":types").Text().Token();

        /// <summary>
        /// The keyword <c>:constants</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Constants =
            Parse.String(":constants").Text().Token();

        /// <summary>
        /// The keyword <c>:timeless</c>
        /// </summary>
        [NotNull] public static readonly Parser<string> Timeless =
            Parse.String(":timeless").Text().Token();

        /// <summary>
        /// The keyword <c>:safety</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Safety =
            Parse.String(":safety").Text().Token();

        /// <summary>
        /// The keyword <c>:domain-variables</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> DomainVariables =
            Parse.String(":domain-variables").Text().Token();
    }
}
