using JetBrains.Annotations;
using PDDL.Model.PDDL12.Goals;

namespace PDDL.Model.PDDL12.Null
{
    /// <summary>
    /// Class NullGoalDescription.
    /// <para>
    ///     Describes a nonexistent goal.
    /// </para>
    /// </summary>
    internal sealed class NullGoalDescription : GoalBase
    {
        /// <summary>
        /// Returns the default instance of the <see cref="NullGoalDescription"/>
        /// </summary>
        /// <value>The default.</value>
        [NotNull]
        public static NullGoalDescription Default { get; } = new NullGoalDescription();

        /// <summary>
        /// Gets the kind of goal.
        /// </summary>
        /// <value>The kind.</value>
        public override GoalKind Kind => GoalKind.None;
    }
}
