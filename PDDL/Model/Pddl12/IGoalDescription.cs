using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IGoalDescription
    /// <para>
    ///     A goal description is used to specify the desired goals in a planning problem and also
    ///     the preconditions for an action.
    /// </para>
    /// </summary>
    public interface IGoalDescription
    {
    }

    /// <summary>
    /// Interface IAtomicGoalDescription
    /// </summary>
    public interface IAtomicGoalDescription : IGoalDescription
    {
        /// <summary>
        /// Gets the condition.
        /// </summary>
        /// <value>The condition.</value>
        [NotNull]
        IAtomicFormula<ITerm> Condition { get; }
    }

    /// <summary>
    /// Interface ILiteralGoalDescription
    /// </summary>
    public interface ILiteralGoalDescription : IGoalDescription
    {
        /// <summary>
        /// Gets the literal.
        /// </summary>
        /// <value>The literal.</value>
        [NotNull]
        ILiteral<ITerm> Literal { get; }
    }

    /// <summary>
    /// Interface IConjunctionGoalDescription
    /// <para>
    ///     Combines multiple goals using an <c>and</c> relationship.
    /// </para>
    /// </summary>
    public interface IConjunctionGoalDescription : IGoalDescription
    {
        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <value>The goals.</value>
        [NotNull]
        IReadOnlyList<IGoalDescription> Goals { get; }
    }
}
