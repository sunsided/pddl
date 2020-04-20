using PDDL.PDDL12.Abstractions;

namespace PDDL.PDDL12.Model.Null
{
    /// <summary>
    /// Class Preconditions.
    /// </summary>
    internal sealed class NullPrecondition : IPrecondition
    {
        /// <summary>
        /// Returns the default instance of the <see cref="NullPrecondition"/>
        /// </summary>
        /// <value>The default.</value>
        public static NullPrecondition Default { get; } = new NullPrecondition();

        /// <summary>
        /// Gets the preconditions.
        /// </summary>
        /// <value>The preconditions.</value>
        public IGoalDescription Preconditions { get; } = NullGoalDescription.Default;
    }
}
