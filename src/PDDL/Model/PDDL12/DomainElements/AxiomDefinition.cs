using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class AxiomDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class AxiomDefinition : IDomainAxiomElement
    {
        /// <summary>
        /// Gets the axiom definition.
        /// </summary>
        /// <value>The axiom.</value>
        public IAxiom Axiom { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDefinition"/> class.
        /// </summary>
        /// <param name="axiom">The axiom.</param>
        /// <exception cref="ArgumentNullException">The value of 'axiom' cannot be null. </exception>
        public AxiomDefinition([NotNull] IAxiom axiom)
        {
            Axiom = axiom ?? throw new ArgumentNullException(nameof(axiom), "The value cannot be null.");
        }
    }
}
