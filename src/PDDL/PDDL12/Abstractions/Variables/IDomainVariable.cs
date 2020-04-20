namespace PDDL.PDDL12.Abstractions.Variables
{
    /// <summary>
    /// Interface IDomainVariable
    /// </summary>
    public interface IDomainVariable
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        IName Name { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        IType Type { get; }
    }
}
