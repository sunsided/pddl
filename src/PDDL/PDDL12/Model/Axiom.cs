﻿using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Variables;

namespace PDDL.PDDL12.Model
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
        public Axiom(IReadOnlyList<IVariableDefinition> variables, IGoalDescription context, ILiteral<ITerm> implication)
        {
            VariableDefinitions = variables ?? throw new ArgumentNullException(nameof(variables));
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Implication = implication ?? throw new ArgumentNullException(nameof(implication));
        }

        /// <summary>
        /// Gets the variable definitions.
        /// </summary>
        /// <value>The variable definitions.</value>
        public IReadOnlyList<IVariableDefinition> VariableDefinitions { get; }

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
