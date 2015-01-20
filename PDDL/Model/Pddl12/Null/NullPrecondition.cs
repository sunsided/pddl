using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Null
{
    /// <summary>
    /// Class Preconditions.
    /// </summary>
    public class NullPrecondition : IPrecondition
    {
        /// <summary>
        /// Gets the preconditions.
        /// </summary>
        /// <value>The preconditions.</value>
        public IGoalDescription Preconditions { get; private set; }

        /// <summary>
        /// The default instance
        /// </summary>
        [NotNull]
        private static readonly NullPrecondition _default = new NullPrecondition();

        /// <summary>
        /// Returns the default instance of the <see cref="NullPrecondition"/>
        /// </summary>
        /// <value>The default.</value>
        [NotNull]
        public static NullPrecondition Default { get { return _default; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="NullPrecondition" /> class.
        /// </summary>
        public NullPrecondition()
        {
            Preconditions = NullGoalDescription.Default;
        }
    }
}
