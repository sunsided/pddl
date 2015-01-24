using JetBrains.Annotations;
using PDDL.Model.PDDL12.Goals;

namespace PDDL.Model.PDDL12.Null
{
    /// <summary>
    /// Class NullGoalDescription.
    /// <para>
    ///     Describes a nonexistant goal.
    /// </para>
    /// </summary>
    public class NullGoalDescription : GoalBase
    {
        /// <summary>
        /// The default instance
        /// </summary>
        [NotNull]
        private static readonly NullGoalDescription _default = new NullGoalDescription();

        /// <summary>
        /// Returns the default instance of the <see cref="NullGoalDescription"/>
        /// </summary>
        /// <value>The default.</value>
        [NotNull]
        public static NullGoalDescription Default { get {  return _default; } }
    }
}
