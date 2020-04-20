using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Problems;

namespace PDDL.PDDL12.Model.ProblemElements
{
    /// <summary>
    /// Class ProblemObjectsDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ProblemObjectsDefinition : IProblemObjectsDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemObjectsDefinition"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public ProblemObjectsDefinition(IReadOnlyList<IObject> value)
        {
            Objects = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        public IReadOnlyList<IObject> Objects { get; }
    }
}
