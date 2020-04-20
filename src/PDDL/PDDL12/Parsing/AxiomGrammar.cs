using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.DomainElements;
using Sprache;

namespace PDDL.PDDL12.Parsing
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
        public static readonly Parser<IDomainAxiomElement> AxiomDefinition = CreateAxiomDefinition();

        /// <summary>
        /// Creates the axiom definition.
        /// </summary>
        /// <returns>Parser&lt;IAxiom&gt;.</returns>
        private static Parser<IDomainAxiomElement> CreateAxiomDefinition()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CAxiom
                from vars in VarsGrammar.VarsDefinition
                from context in Keywords.CContext.Then(_ => GoalGrammar.GoalDescription)
                from implications in Keywords.CImplies.Then(_ => CommonGrammar.LiteralOfTerm)
                from close in CommonGrammar.ClosingParenthesis
                // bundle and go
                let axiom = new Axiom(vars.ToList(), context, implications)
                select new AxiomDefinition(axiom)
                ).Token();
        }
    }
}
