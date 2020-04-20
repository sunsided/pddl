namespace PDDL.PDDL12.Abstractions.Variables
{
    /// <summary>
    /// Interface IConstantDomainVariable
    /// </summary>
    public interface IConstantDomainVariable : IDomainVariable
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        IValue Value { get; }
    }
}
