using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface IProblem
    /// </summary>
    public interface IProblem : IDefinition
    {
        // TODO: add situation
        // TODO: add length

        /// <summary>
        /// Gets the name of the problem.
        /// </summary>
        /// <value>The problem.</value>
        IName Name { get; }

        /// <summary>
        /// Gets the name of the domain the problem is defined in.
        /// </summary>
        /// <value>The domain.</value>
        IName Domain { get; }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        IReadOnlyList<IRequirement> Requirements { get; }

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <value>The objects.</value>
        IReadOnlyList<IObject> Objects { get; }

        /// <summary>
        /// Gets the initial state or, should a situation be set,
        /// additional effects of the given situation.
        /// </summary>
        /// <value>The initial state.</value>
        IReadOnlyList<ILiteral<IName>> Initial { get; }

        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <value>The goals.</value>
        IReadOnlyList<IGoalDescription> Goals { get; }
    }
}
