using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IAxiom
    /// </summary>
    public interface IAxiom
    {
        /// <summary>
        /// Gets the variables.
        /// </summary>
        /// <value>The variables.</value>
        [NotNull]
        IReadOnlyList<IVariable> Variables { get; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        [NotNull]
        IGoalDescription Context { get; }

        /// <summary>
        /// Gets the implication.
        /// </summary>
        /// <value>The implication.</value>
        [NotNull]
        ILiteral<ITerm> Implication { get; }
    }
}
