using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.ProblemElements
{
    /// <summary>
    /// Class ProblemInitialStateDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ProblemInitialStateDefinition : IProblemInitialStateDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProblemInitialStateDefinition"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public ProblemInitialStateDefinition([NotNull] IReadOnlyList<ILiteral<IName>> value)
        {
            State = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the initial state.
        /// </summary>
        /// <value>The initial state.</value>
        public IReadOnlyList<ILiteral<IName>> State { get; }
    }
}
