using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Null
{
    /// <summary>
    /// Class Preconditions.
    /// </summary>
    public sealed class NullPrecondition : IPrecondition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullPrecondition" /> class.
        /// </summary>
        public NullPrecondition()
        {
            Preconditions = NullGoalDescription.Default;
        }

        /// <summary>
        /// Returns the default instance of the <see cref="NullPrecondition"/>
        /// </summary>
        /// <value>The default.</value>
        [NotNull]
        public static NullPrecondition Default { get; } = new NullPrecondition();

        /// <summary>
        /// Gets the preconditions.
        /// </summary>
        /// <value>The preconditions.</value>
        public IGoalDescription Preconditions { get; }
    }
}
