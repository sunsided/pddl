using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
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
        [NotNull]
        IValue Value { get; }
    }
}
