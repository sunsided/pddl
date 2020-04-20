using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class PredicatesDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class PredicatesDefinition : IDomainPredicatesDefinition
    {
        /// <summary>
        /// Gets the predicate definitions.
        /// </summary>
        /// <value>The predicate.</value>
        public IReadOnlyList<IAtomicFormulaSkeleton> Predicates { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicatesDefinition"/> class.
        /// </summary>
        /// <param name="predicates">The types.</param>
        /// <exception cref="ArgumentNullException">The value of 'predicates' cannot be null. </exception>
        public PredicatesDefinition([NotNull] IReadOnlyList<IAtomicFormulaSkeleton> predicates)
        {
            Predicates = predicates ?? throw new ArgumentNullException(nameof(predicates), "The value cannot be null.");
        }
    }
}
