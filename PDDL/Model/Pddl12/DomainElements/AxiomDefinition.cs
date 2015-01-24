using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class AxiomDefinition. This class cannot be inherited.
    /// </summary>
    public sealed class AxiomDefinition : IDomainAxiomElement
    {
        /// <summary>
        /// Gets the axiom definition.
        /// </summary>
        /// <value>The axiom.</value>
        [NotNull]
        public IAxiom Axiom { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDefinition"/> class.
        /// </summary>
        /// <param name="axiom">The axiom.</param>
        /// <exception cref="ArgumentNullException">The value of 'axiom' cannot be null. </exception>
        public AxiomDefinition([NotNull] IAxiom axiom)
        {
            if (ReferenceEquals(axiom, null)) throw new ArgumentNullException("axiom", "The value cannot be null.");
            Axiom = axiom;
        }
    }
}
