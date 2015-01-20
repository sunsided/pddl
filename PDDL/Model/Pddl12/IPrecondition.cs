using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IPrecondition
    /// </summary>
    public interface IPrecondition
    {
        /// <summary>
        /// Gets the preconditions.
        /// </summary>
        /// <value>The preconditions.</value>
        [NotNull]
        IGoalDescription Preconditions { get; }
    }
}
