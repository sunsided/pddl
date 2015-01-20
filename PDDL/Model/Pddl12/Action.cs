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
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="precondition">The precondition.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'parameters', 'precondition' and 'effect' cannot be null. </exception>
        public Action([NotNull] IReadOnlyList<IVariable> parameters, [NotNull] IPrecondition precondition, [NotNull] IEffect effect)
        {
            if (ReferenceEquals(parameters, null)) throw new ArgumentNullException("parameters", "parameters must not be null");
            if (ReferenceEquals(precondition, null)) throw new ArgumentNullException("precondition", "parameters must not be null");
            if (ReferenceEquals(effect, null)) throw new ArgumentNullException("effect", "effect must not be null");

            Parameters = parameters;
            Precondition = precondition;
            Effect = effect;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'parameters' and 'effect' cannot be null. </exception>
        public Action([NotNull] IReadOnlyList<IVariable> parameters, [NotNull] IEffect effect)
            : this(parameters, NullPrecondition.Default, effect)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="precondition">The precondition.</param>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'precondition' and 'effect' cannot be null. </exception>
        public Action([NotNull] IPrecondition precondition, [NotNull] IEffect effect)
            : this(new IVariable[0], precondition, effect)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Action"/> class.
        /// </summary>
        /// <param name="effect">The effect.</param>
        /// <exception cref="ArgumentNullException">The value of 'effect' cannot be null. </exception>
        public Action([NotNull] IEffect effect)
            : this(NullPrecondition.Default, effect)
        {
        }
    }
}
