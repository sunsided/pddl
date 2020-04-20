using JetBrains.Annotations;
using Sprache;

namespace PDDL.Parser.PDDL12
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
        public static readonly Parser<string> Not = Parse.String("not").Text().Token();

        /// <summary>
        /// The keyword <c>and</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> And = Parse.String("and").Text().Token();

        /// <summary>
        /// The keyword <c>:precondition</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CPrecondition = Parse.String(":precondition").Text().Token();

        /// <summary>
        /// The keyword <c>:parameters</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CParameters = Parse.String(":parameters").Text().Token();

        /// <summary>
        /// The keyword <c>:effect</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CEffect = Parse.String(":effect").Text().Token();

        /// <summary>
        /// The keyword <c>:action</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CAction = Parse.String(":action").Text().Token();

        /// <summary>
        /// The keyword <c>:vars</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CVars = Parse.String(":vars").Text().Token();

        /// <summary>
        /// The keyword <c>:axiom</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CAxiom = Parse.String(":axiom").Text().Token();

        /// <summary>
        /// The keyword <c>:context</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CContext = Parse.String(":context").Text().Token();

        /// <summary>
        /// The keyword <c>:implies</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CImplies = Parse.String(":implies").Text().Token();

        /// <summary>
        /// The keyword <c>define</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Define = Parse.String("define").Text().Token();

        /// <summary>
        /// The keyword <c>domain</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Domain = Parse.String("domain").Text().Token();

        /// <summary>
        /// The keyword <c>problem</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> Problem = Parse.String("problem").Text().Token();

        /// <summary>
        /// The keyword <c>:predicates</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CPredicates = Parse.String(":predicates").Text().Token();

        /// <summary>
        /// The keyword <c>:extends</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CExtends = Parse.String(":extends").Text().Token();

        /// <summary>
        /// The keyword <c>:requirements</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CRequirements = Parse.String(":requirements").Text().Token();

        /// <summary>
        /// The keyword <c>:types</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CTypes = Parse.String(":types").Text().Token();

        /// <summary>
        /// The keyword <c>:constants</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CConstants = Parse.String(":constants").Text().Token();

        /// <summary>
        /// The keyword <c>:timeless</c>
        /// </summary>
        [NotNull] public static readonly Parser<string> CTimeless = Parse.String(":timeless").Text().Token();

        /// <summary>
        /// The keyword <c>:safety</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CSafety = Parse.String(":safety").Text().Token();

        /// <summary>
        /// The keyword <c>:domain-variables</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CDomainVariables = Parse.String(":domain-variables").Text().Token();

        /// <summary>
        /// The keyword <c>:domain</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CDomain = Parse.String(":domain").Text().Token();

        /// <summary>
        /// The keyword <c>:situation</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CSituation = Parse.String(":situation").Text().Token();

        /// <summary>
        /// The keyword <c>:objects</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CObjects = Parse.String(":objects").Text().Token();

        /// <summary>
        /// The keyword <c>:init</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CInit = Parse.String(":init").Text().Token();

        /// <summary>
        /// The keyword <c>:goal</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CGoal = Parse.String(":goal").Text().Token();

        /// <summary>
        /// The keyword <c>:length</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CLength = Parse.String(":length").Text().Token();

        /// <summary>
        /// The keyword <c>:expansion</c>
        /// </summary>
        [NotNull]
        public static readonly Parser<string> CExpansion = Parse.String(":expansion").Text().Token();
    }
}
