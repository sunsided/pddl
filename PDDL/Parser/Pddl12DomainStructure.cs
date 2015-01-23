using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;

namespace PDDL.Parser
{
    /// <summary>
    /// Class Pddl12DomainStructure. This class cannot be inherited.
    /// </summary>
    internal sealed class Pddl12DomainStructure
    {
        /// <summary>
        /// Gets or sets the axiom.
        /// </summary>
        /// <value>The axiom.</value>
        [CanBeNull]
        public IReadOnlyList<IAction> Actions { get; set; }

        /// <summary>
        /// Gets or sets the axiom.
        /// </summary>
        /// <value>The axiom.</value>
        [CanBeNull]
        public IReadOnlyList<IAxiom> Axioms { get; set; }
    }
}
