using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.ProblemElements
{
    /// <summary>
    /// Class ProblemRequireDefinition. This class cannot be inherited.
    /// </summary>
    public sealed class ProblemRequireDefinition : IProblemRequireDefinition
    {
        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        [NotNull]
        public IReadOnlyList<IRequirement> Requirements { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemRequireDefinition"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public ProblemRequireDefinition([NotNull] IReadOnlyList<IRequirement> value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
            Requirements = value;
        }
    }
}
