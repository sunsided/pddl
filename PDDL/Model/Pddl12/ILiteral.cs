using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface ILiteral
    /// <para>
    ///     Literals are used to describe positive and negative predicates and goals, as well as effects.
    /// </para>
    /// </summary>
    public interface ILiteral : IAtomicFormulaSkeleton
    {
        /// <summary>
        /// Determines if the atomic is positive.
        /// </summary>
        /// <value><c>true</c> if the atomic is positive.</value>
        [NotNull]
        bool Positive { get; }
    }
}
