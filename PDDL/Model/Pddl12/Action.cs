using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.Pddl12.Null;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Class Action.
    /// </summary>
    public class Action : IAction
    {
        /// <summary>
        /// The variables (<c>:vars</c>)
        /// </summary>
        private IReadOnlyList<IVariable> _variables = new IVariable[0];

        /// <summary>
        /// Gets the functor.
        /// </summary>
        /// <value>The functor.</value>
        public IName Functor { get; private set; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public IReadOnlyList<IVariable> Parameters { get; private set; }

        /// <summary>
        /// Gets the precondition.
        /// </summary>
        /// <value>The precondition.</value>
        public IPrecondition Precondition { get; private set; }

        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        public IEffect Effect { get; private set; }

        /// <summary>
        /// Gets or sets the variables (<c>:vars</c>).
        /// </summary>
        /// <value>The variables.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        [NotNull]
        public IReadOnlyList<IVariable> Variables
        {
            get { return _variables; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _variables = value;
            }
        }

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
        public Action([NotNull] IName functor, [NotNull] IReadOnlyList<IVariable> parameters, [NotNull] IPrecondition precondition, [NotNull] IEffect effect)
        {
            if (ReferenceEquals(functor, null)) throw new ArgumentNullException("functor", "functor must not be null");
            if (ReferenceEquals(parameters, null)) throw new ArgumentNullException("parameters", "parameters must not be null");
            if (ReferenceEquals(precondition, null)) throw new ArgumentNullException("precondition", "parameters must not be null");
            if (ReferenceEquals(effect, null)) throw new ArgumentNullException("effect", "effect must not be null");

            Functor = functor;
            Parameters = parameters;
            Precondition = precondition;
            Effect = effect;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        /// <param name="functor">The functor.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'functor', 'parameters' and 'effect' cannot be null.</exception>
        public Action([NotNull] IName functor, [NotNull] IReadOnlyList<IVariable> parameters, [NotNull] IEffect effect)
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
        public Action([NotNull] IName functor, [NotNull] IPrecondition precondition, [NotNull] IEffect effect)
            : this(functor, new IVariable[0], precondition, effect)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action" /> class.
        /// </summary>
        /// <param name="functor">The functor.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'functor', 'effect' cannot be null.</exception>
        public Action([NotNull] IName functor, [NotNull] IEffect effect)
            : this(functor, NullPrecondition.Default, effect)
        {
        }
    }
}
