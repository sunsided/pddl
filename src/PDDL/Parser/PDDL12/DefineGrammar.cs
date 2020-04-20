using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.PDDL12;
using Sprache;

namespace PDDL.Parser.PDDL12
{
    /// <summary>
    /// Class DefineGrammar.
    /// </summary>
    internal static class DefineGrammar
    {
        /// <summary>
        /// The define definition
        /// </summary>
        [NotNull]
        private static readonly Parser<IDefinition> DefineDefinition
            = CreateDefineDefinition();

        /// <summary>
        /// Multiple defines
        /// </summary>
        [NotNull]
        public static readonly Parser<IEnumerable<IDefinition>> MultiDefineDefinition
            = DefineDefinition.AtLeastOnce();

        /// <summary>
        /// Creates the define definition.
        /// </summary>
        /// <returns>Parser&lt;IDomain&gt;.</returns>
        [NotNull]
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
