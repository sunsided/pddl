using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Variables;
using PDDL.PDDL12.Model.Null;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class Action.
    /// </summary>
    internal sealed class Action : IAction
    {
        /// <summary>
        /// The variables (<c>:vars</c>)
        /// </summary>
        private IReadOnlyList<IVariableDefinition> _variables = new IVariableDefinition[0];

        /// <summary>
        /// Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        /// <param name="functor">The functor.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="precondition">The precondition.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="System.ArgumentNullException">
        /// functor;functor must not be null
        /// or
        /// parameters;parameters must not be null
        /// or
        /// precondition;parameters must not be null
        /// or
        /// effect;effect must not be null
        /// </exception>
        /// <exception cref="ArgumentNullException">The value of 'functor', 'parameters', 'precondition' and 'effect' cannot be null.</exception>
        public Action(IName functor, IReadOnlyList<IVariableDefinition> parameters, IPrecondition precondition, IEffect effect)
        {
            Functor = functor ?? throw new ArgumentNullException(nameof(functor), "functor must not be null");
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters), "parameters must not be null");
            Precondition = precondition ?? throw new ArgumentNullException(nameof(precondition), "parameters must not be null");
            Effect = effect ?? throw new ArgumentNullException(nameof(effect), "effect must not be null");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        /// <param name="functor">The functor.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'functor', 'parameters' and 'effect' cannot be null.</exception>
        public Action(IName functor, IReadOnlyList<IVariableDefinition> parameters, IEffect effect)
            : this(functor, parameters, NullPrecondition.Default, effect)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        /// <param name="functor">The functor.</param>
        /// <param name="precondition">The precondition.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'functor', 'precondition' and 'effect' cannot be null.</exception>
        public Action(IName functor, IPrecondition precondition, IEffect effect)
            : this(functor, new IVariableDefinition[0], precondition, effect)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        /// <param name="functor">The functor.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'functor', 'effect' cannot be null.</exception>
        public Action(IName functor, IEffect effect)
            : this(functor, NullPrecondition.Default, effect)
        {
        }

        /// <summary>
        /// Gets the functor.
        /// </summary>
        /// <value>The functor.</value>
        public IName Functor { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public IReadOnlyList<IVariableDefinition> Parameters { get; }

        /// <summary>
        /// Gets the precondition.
        /// </summary>
        /// <value>The precondition.</value>
        public IPrecondition Precondition { get; }

        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        public IEffect Effect { get; }

        /// <summary>
        /// Gets or sets the variables (<c>:vars</c>).
        /// </summary>
        /// <value>The variables.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IVariableDefinition> Variables
        {
            get => _variables;
            set => _variables = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}
