using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.ProblemElements
{
    /// <summary>
    /// Class ProblemRequireDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ProblemRequireDefinition : IProblemRequireDefinition
    {
        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        public IReadOnlyList<IRequirement> Requirements { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemRequireDefinition"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public ProblemRequireDefinition([NotNull] IReadOnlyList<IRequirement> value)
        {
            Requirements = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
