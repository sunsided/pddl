using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Abstractions.Variables;

namespace PDDL.PDDL12.Model.DomainElements
{
    /// <summary>
    /// Class VarsDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class VarsDefinition : IDomainVarsDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VarsDefinition"/> class.
        /// </summary>
        /// <param name="variables">The safety.</param>
        /// <exception cref="ArgumentNullException">The value of 'variables' cannot be null. </exception>
        public VarsDefinition(IReadOnlyList<IDomainVariable> variables)
        {
            Variables = variables ?? throw new ArgumentNullException(nameof(variables), "The value of 'variables' cannot be null.");
        }

        /// <summary>
        /// Gets the safety constraints.
        /// </summary>
        /// <value>The safety constraints.</value>
        public IReadOnlyList<IDomainVariable> Variables { get; }
    }
}
