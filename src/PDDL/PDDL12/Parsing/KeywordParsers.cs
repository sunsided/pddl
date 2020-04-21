using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class Keywords.
    /// </summary>
    internal sealed class KeywordParsers
    {
        /// <summary>
        /// The keyword <c>not</c>
        /// </summary>
        public Parser<string> Not { get; } = Parse.String("not").Text().Token();

        /// <summary>
        /// The keyword <c>and</c>
        /// </summary>
        public Parser<string> And { get; } = Parse.String("and").Text().Token();

        /// <summary>
        /// The keyword <c>:precondition</c>
        /// </summary>
        public Parser<string> CPrecondition { get; } = Parse.String(":precondition").Text().Token();

        /// <summary>
        /// The keyword <c>:parameters</c>
        /// </summary>
        public Parser<string> CParameters { get; } = Parse.String(":parameters").Text().Token();

        /// <summary>
        /// The keyword <c>:effect</c>
        /// </summary>
        public Parser<string> CEffect { get; } = Parse.String(":effect").Text().Token();

        /// <summary>
        /// The keyword <c>:action</c>
        /// </summary>
        public Parser<string> CAction { get; } = Parse.String(":action").Text().Token();

        /// <summary>
        /// The keyword <c>:vars</c>
        /// </summary>
        public Parser<string> CVars { get; } = Parse.String(":vars").Text().Token();

        /// <summary>
        /// The keyword <c>:axiom</c>
        /// </summary>
        public Parser<string> CAxiom { get; } = Parse.String(":axiom").Text().Token();

        /// <summary>
        /// The keyword <c>:context</c>
        /// </summary>
        public Parser<string> CContext { get; } = Parse.String(":context").Text().Token();

        /// <summary>
        /// The keyword <c>:implies</c>
        /// </summary>
        public Parser<string> CImplies { get; } = Parse.String(":implies").Text().Token();

        /// <summary>
        /// The keyword <c>define</c>
        /// </summary>
        public Parser<string> Define { get; } = Parse.String("define").Text().Token();

        /// <summary>
        /// The keyword <c>domain</c>
        /// </summary>
        public Parser<string> Domain { get; } = Parse.String("domain").Text().Token();

        /// <summary>
        /// The keyword <c>problem</c>
        /// </summary>
        public Parser<string> Problem { get; } = Parse.String("problem").Text().Token();

        /// <summary>
        /// The keyword <c>:predicates</c>
        /// </summary>
        public Parser<string> CPredicates { get; } = Parse.String(":predicates").Text().Token();

        /// <summary>
        /// The keyword <c>:extends</c>
        /// </summary>
        public Parser<string> CExtends { get; } = Parse.String(":extends").Text().Token();

        /// <summary>
        /// The keyword <c>:requirements</c>
        /// </summary>
        public Parser<string> CRequirements { get; } = Parse.String(":requirements").Text().Token();

        /// <summary>
        /// The keyword <c>:types</c>
        /// </summary>
        public Parser<string> CTypes { get; } = Parse.String(":types").Text().Token();

        /// <summary>
        /// The keyword <c>:constants</c>
        /// </summary>
        public Parser<string> CConstants { get; } = Parse.String(":constants").Text().Token();

        /// <summary>
        /// The keyword <c>:timeless</c>
        /// </summary>
        public Parser<string> CTimeless { get; } = Parse.String(":timeless").Text().Token();

        /// <summary>
        /// The keyword <c>:safety</c>
        /// </summary>
        public Parser<string> CSafety { get; } = Parse.String(":safety").Text().Token();

        /// <summary>
        /// The keyword <c>:domain-variables</c>
        /// </summary>
        public Parser<string> CDomainVariables { get; } = Parse.String(":domain-variables").Text().Token();

        /// <summary>
        /// The keyword <c>:domain</c>
        /// </summary>
        public Parser<string> CDomain { get; } = Parse.String(":domain").Text().Token();

        /// <summary>
        /// The keyword <c>:situation</c>
        /// </summary>
        public Parser<string> CSituation { get; } = Parse.String(":situation").Text().Token();

        /// <summary>
        /// The keyword <c>:objects</c>
        /// </summary>
        public Parser<string> CObjects { get; } = Parse.String(":objects").Text().Token();

        /// <summary>
        /// The keyword <c>:init</c>
        /// </summary>
        public Parser<string> CInit { get; } = Parse.String(":init").Text().Token();

        /// <summary>
        /// The keyword <c>:goal</c>
        /// </summary>
        public Parser<string> CGoal { get; } = Parse.String(":goal").Text().Token();

        /// <summary>
        /// The keyword <c>:length</c>
        /// </summary>
        public Parser<string> CLength { get; } = Parse.String(":length").Text().Token();

        /// <summary>
        /// The keyword <c>:expansion</c>
        /// </summary>
        public Parser<string> CExpansion { get; } = Parse.String(":expansion").Text().Token();
    }
}
