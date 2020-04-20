using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class DefineGrammar.
    /// </summary>
    internal static class DefineGrammar
    {
        /// <summary>
        /// The define definition
        /// </summary>
        private static readonly Parser<IDefinition> DefineDefinition
            = CreateDefineDefinition();

        /// <summary>
        /// Multiple defines
        /// </summary>
        public static readonly Parser<IEnumerable<IDefinition>> MultiDefineDefinition
            = DefineDefinition.AtLeastOnce();

        /// <summary>
        /// Creates the define definition.
        /// </summary>
        /// <returns>Parser&lt;IDomain&gt;.</returns>
        private static Parser<IDefinition> CreateDefineDefinition() =>
        (
            from openDefine in CommonGrammar.OpeningParenthesis
            from defineKeyword in Keywords.Define
            from definition in DomainGrammar.DomainDefinition.Or<IDefinition>(ProblemGrammar.ProblemDefinition)
            from closeDefine in CommonGrammar.ClosingParenthesis
            select definition
        );
    }
}
