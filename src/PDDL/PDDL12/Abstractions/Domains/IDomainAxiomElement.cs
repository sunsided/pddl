namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainActionElement
    /// </summary>
    public interface IDomainAxiomElement : IDomainStructureElement
    {
        /// <summary>
        /// Gets the axiom definition.
        /// </summary>
        /// <value>The axiom.</value>
        IAxiom Axiom { get; }
    }
}
