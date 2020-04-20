using System.Collections.Generic;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Abstractions.Variables;

namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface IAction
    /// </summary>
    public interface IAction : IDomainStructureElement
    {
        /// <summary>
        /// Gets the functor.
        /// </summary>
        /// <value>The functor.</value>
        IName Functor { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        IReadOnlyList<IVariableDefinition> Parameters { get; }

        /// <summary>
        /// Gets the precondition.
        /// </summary>
        /// <value>The precondition.</value>
        IPrecondition Precondition { get; }

        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        IEffect Effect { get; }

        /// <summary>
        /// Gets othe variables (<c>:vars</c>).
        /// </summary>
        /// <value>The variables.</value>
        IReadOnlyList<IVariableDefinition> Variables { get; }
    }
}
