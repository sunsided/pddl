using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class Axiom.
    /// </summary>
    public class Axiom : IAxiom
    {
        /// <summary>
        /// Gets the variables.
        /// </summary>
        /// <value>The variables.</value>
        public IReadOnlyList<IVariableDefinition> Variables { get; private set; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        public IGoalDescription Context { get; private set; }

        /// <summary>
        /// Gets the implication.
        /// </summary>
        /// <value>The implication.</value>
        public ILiteral<ITerm> Implication { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Axiom"/> class.
        /// </summary>
        /// <param name="variables">The variables.</param>
        /// <param name="context">The context.</param>
        /// <param name="implication">The implication.</param>
        /// <exception cref="ArgumentNullException">The value of 'variables', 'context' and 'implication' cannot be null.</exception>
        public Axiom([NotNull] IReadOnlyList<IVariableDefinition> variables, [NotNull] IGoalDescription context, [NotNull] ILiteral<ITerm> implication)
        {
            if (ReferenceEquals(variables, null)) throw new ArgumentNullException("variables");
            if (ReferenceEquals(context, null)) throw new ArgumentNullException("context");
            if (ReferenceEquals(implication, null)) throw new ArgumentNullException("implication");

            Variables = variables;
            Context = context;
            Implication = implication;
        }
    }
}
