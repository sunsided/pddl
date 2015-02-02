using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Interface ISubstitution
    /// </summary>
    public interface ISubstitution
    {
        /// <summary>
        /// Gets the variable.
        /// </summary>
        /// <value>The variable.</value>
        [NotNull]
        IVariableDefinition Variable { get; }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>The object.</value>
        [NotNull]
        ITerm Object { get; }
    }
}
