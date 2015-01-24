using System.Linq;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class AxiomGrammar.
    /// </summary>
    internal static class AxiomGrammar
    {
        /// <summary>
        /// Gets or sets the axioms.
        /// </summary>
        /// <value>The axioms.</value>
        [NotNull]
        public static readonly Parser<IAxiom> AxiomDefinition =
            CreateAxiomDefinition();

        #region Factory Functions

        /// <summary>
        /// Creates the axiom definition.
        /// </summary>
        /// <returns>Parser&lt;IAxiom&gt;.</returns>
        [NotNull]
        private static Parser<IAxiom> CreateAxiomDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Axiom
                from vars in VarsGrammar.VarsDefinition
                from context in Keywords.Context.Then(_ => GoalGrammar.GoalDescription)
                from implications in Keywords.Implies.Then(_ => CommonGrammar.LiteralOfTerm)
                from close in CommonGrammar.ClosingParenthesis
                select new Axiom(vars.ToList(), context, implications)
                ).Token();
        }

        #endregion
    }
}
