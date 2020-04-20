namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface IVariable
    /// </summary>
    public interface IVariable : ITerm
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        IName Name { get; }
    }
}
