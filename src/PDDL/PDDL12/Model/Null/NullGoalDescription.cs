using PDDL.PDDL12.Abstractions.Goals;
using PDDL.PDDL12.Model.Goals;

namespace PDDL.PDDL12.Model.Null
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
        public static NullGoalDescription Default { get; } = new NullGoalDescription();

        /// <summary>
        /// Gets the kind of goal.
        /// </summary>
        /// <value>The kind.</value>
        public override GoalKind Kind => GoalKind.None;
    }
}
