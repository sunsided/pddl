using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class DefineGrammar.
    /// </summary>
    internal static class DefineGrammar
    {
        /// <summary>
        /// The define definition
        /// </summary>
        [NotNull] public static readonly Parser<IDomain> DefineDefinition
            = CreateDefineDefinition();

        #region Factory Functions

        /// <summary>
        /// Creates the define definition.
        /// </summary>
        /// <returns>Parser&lt;IDomain&gt;.</returns>
        [NotNull]
        private static Parser<IDomain> CreateDefineDefinition()
        {
            return (
                from openDefine in CommonGrammar.OpeningParenthesis
                from defineKeyword in Keywords.Define
                from domain in DomainGrammar.DomainDefinition
                from closeDefine in CommonGrammar.ClosingParenthesis
                select domain
                );
        }

        #endregion
    }
}
