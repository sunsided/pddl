using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Interface IGoalDefinitionElement
    /// </summary>
    public interface IProblemDefinitionElement
    {
        // intentionally left blank
    }
    
    /// <summary>
    /// Interface IProblemRequireDefinition
    /// </summary>
    public interface IProblemRequireDefinition : IProblemDefinitionElement
    {
        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        [NotNull]
        IReadOnlyList<IRequirement> Requirements { get; }
    }

    /// <summary>
    /// Interface IProblemInitialStateDefinition
    /// </summary>
    public interface IProblemInitialStateDefinition : IProblemDefinitionElement
    {
        /// <summary>
        /// Gets the initial state.
        /// </summary>
        /// <value>The initial state.</value>
        [NotNull]
        IReadOnlyList<ILiteral<IName>> State { get; }
    }

    /// <summary>
    /// Interface IProblemObjectsDefinition
    /// </summary>
    public interface IProblemObjectsDefinition : IProblemDefinitionElement
    {
        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <value>The objects.</value>
        [NotNull]
        IReadOnlyList<IObject> Objects { get; }
    }

    /// <summary>
    /// Interface IProblemGoalDefinition
    /// </summary>
    public interface IProblemGoalDefinition : IProblemDefinitionElement
    {
        /// <summary>
        /// Gets the goal.
        /// </summary>
        /// <value>The goal.</value>
        [NotNull]
        IGoalDescription Goal { get; }
    }
}
