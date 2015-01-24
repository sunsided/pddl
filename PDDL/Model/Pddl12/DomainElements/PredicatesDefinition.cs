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
        [NotNull]
        public IReadOnlyList<IAtomicFormulaSkeleton> Predicates { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PredicatesDefinition"/> class.
        /// </summary>
        /// <param name="predicates">The types.</param>
        /// <exception cref="ArgumentNullException">The value of 'predicates' cannot be null. </exception>
        public PredicatesDefinition([NotNull] IReadOnlyList<IAtomicFormulaSkeleton> predicates)
        {
            if (ReferenceEquals(predicates, null)) throw new ArgumentNullException("predicates", "The value cannot be null.");
            Predicates = predicates;
        }
    }
}
