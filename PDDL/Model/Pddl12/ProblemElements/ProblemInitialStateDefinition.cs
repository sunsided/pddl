using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.ProblemElements
{
    /// <summary>
    /// Class ProblemInitialStateDefinition. This class cannot be inherited.
    /// </summary>
    public sealed class ProblemInitialStateDefinition : IProblemInitialStateDefinition
    {
        /// <summary>
        /// Gets the initial state.
        /// </summary>
        /// <value>The initial state.</value>
        [NotNull]
        public IReadOnlyList<ILiteral<IName>> State { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemInitialStateDefinition"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public ProblemInitialStateDefinition([NotNull] IReadOnlyList<ILiteral<IName>> value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
            State = value;
        }
    }
}
