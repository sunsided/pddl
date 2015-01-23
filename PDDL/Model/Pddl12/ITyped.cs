using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface ITyped
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITyped<out T>
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [NotNull]
        T Value { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        [NotNull]
        IType Type { get; }
    }
}
