using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IAction
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Gets the functor.
        /// </summary>
        /// <value>The functor.</value>
        [NotNull]
        IName Functor { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        [NotNull]
        IReadOnlyList<IVariable> Parameters { get; }

        /// <summary>
        /// Gets the precondition.
        /// </summary>
        /// <value>The precondition.</value>
        [NotNull]
        IPrecondition Precondition { get; }

        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        IEffect Effect { get; }
    }
}
