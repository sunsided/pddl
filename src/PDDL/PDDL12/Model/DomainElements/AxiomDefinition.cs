using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Domains;

namespace PDDL.PDDL12.Model.DomainElements
{
    /// <summary>
    /// Class AxiomDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class AxiomDefinition : IDomainAxiomElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDefinition"/> class.
        /// </summary>
        /// <param name="axiom">The axiom.</param>
        /// <exception cref="ArgumentNullException">The value of 'axiom' cannot be null. </exception>
        public AxiomDefinition(IAxiom axiom)
        {
            Axiom = axiom ?? throw new ArgumentNullException(nameof(axiom), "The value cannot be null.");
        }

        /// <summary>
        /// Gets the axiom definition.
        /// </summary>
        /// <value>The axiom.</value>
        public IAxiom Axiom { get; }
    }
}
