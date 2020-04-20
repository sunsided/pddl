using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Domains;

namespace PDDL.PDDL12.Model.DomainElements
{
    /// <summary>
    /// Class PredicatesDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class PredicatesDefinition : IDomainPredicatesDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PredicatesDefinition"/> class.
        /// </summary>
        /// <param name="predicates">The types.</param>
        /// <exception cref="ArgumentNullException">The value of 'predicates' cannot be null. </exception>
        public PredicatesDefinition(IReadOnlyList<IAtomicFormulaSkeleton> predicates)
        {
            Predicates = predicates ?? throw new ArgumentNullException(nameof(predicates), "The value cannot be null.");
        }

        /// <summary>
        /// Gets the predicate definitions.
        /// </summary>
        /// <value>The predicate.</value>
        public IReadOnlyList<IAtomicFormulaSkeleton> Predicates { get; }
    }
}
