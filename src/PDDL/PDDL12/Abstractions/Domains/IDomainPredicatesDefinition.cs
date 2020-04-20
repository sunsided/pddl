using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Domains
{
    /// <summary>
    /// Interface IDomainPredicatesDefinition
    /// </summary>
    public interface IDomainPredicatesDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the predicate definitions.
        /// </summary>
        /// <value>The predicate.</value>
        IReadOnlyList<IAtomicFormulaSkeleton> Predicates { get; }
    }
}
