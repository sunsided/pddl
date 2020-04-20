using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class Axiom.
    /// </summary>
    internal sealed class Axiom : IAxiom
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Axiom"/> class.
        /// </summary>
        /// <param name="variables">The variables.</param>
        /// <param name="context">The context.</param>
        /// <param name="implication">The implication.</param>
        /// <exception cref="ArgumentNullException">The value of 'variables', 'context' and 'implication' cannot be null.</exception>
        public Axiom([NotNull] IReadOnlyList<IVariableDefinition> variables, [NotNull] IGoalDescription context, [NotNull] ILiteral<ITerm> implication)
        {
            Variables = variables ?? throw new ArgumentNullException(nameof(variables));
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Implication = implication ?? throw new ArgumentNullException(nameof(implication));
        }

        /// <summary>
        /// Gets the variables.
        /// </summary>
        /// <value>The variables.</value>
        public IReadOnlyList<IVariableDefinition> Variables { get; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public IGoalDescription Context { get; }

        /// <summary>
        /// Gets the implication.
        /// </summary>
        /// <value>The implication.</value>
        public ILiteral<ITerm> Implication { get; }
    }
}
