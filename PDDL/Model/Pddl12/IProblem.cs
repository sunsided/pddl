using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IProblem
    /// </summary>
    public interface IProblem
    {
        // TODO: add situation
        // TODO: add length

        /// <summary>
        /// Gets the name of the problem.
        /// </summary>
        /// <value>The problem.</value>
        [NotNull]
        IName Name { get; }

        /// <summary>
        /// Gets the name of the domain the problem is defined in.
        /// </summary>
        /// <value>The domain.</value>
        [NotNull]
        IName Domain { get; }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        [NotNull]
        IReadOnlyList<IRequirement> Requirements { get; }

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <value>The objects.</value>
        [NotNull]
        IReadOnlyList<ILiteral<IName>> Objects { get; }

        /// <summary>
        /// Gets the initial state or, should a situation be set,
        /// additional effects of the given situation.
        /// </summary>
        /// <value>The initial state.</value>
        [NotNull]
        IReadOnlyList<ILiteral<IName>> Initial { get; }

        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <value>The goals.</value>
        [NotNull]
        IReadOnlyList<IGoalDescription> Goals { get; }
    }
}
