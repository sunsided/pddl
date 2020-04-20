namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainActionElement
    /// </summary>
    public interface IDomainActionElement : IDomainStructureElement
    {
        /// <summary>
        /// Gets the action definition.
        /// </summary>
        /// <value>The action.</value>
        IAction Action { get; }
    }
}
