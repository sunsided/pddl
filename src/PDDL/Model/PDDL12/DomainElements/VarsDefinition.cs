using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class VarsDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class VarsDefinition : IDomainVarsDefinition
    {
        /// <summary>
        /// Gets the safety constraints.
        /// </summary>
        /// <value>The safety constraints.</value>
        public IReadOnlyList<IDomainVariable> Variables { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VarsDefinition"/> class.
        /// </summary>
        /// <param name="variables">The safety.</param>
        /// <exception cref="ArgumentNullException">The value of 'variables' cannot be null. </exception>
        public VarsDefinition([NotNull] IReadOnlyList<IDomainVariable> variables)
        {
            Variables = variables ?? throw new ArgumentNullException(nameof(variables), "The value of 'variables' cannot be null.");
        }
    }
}
