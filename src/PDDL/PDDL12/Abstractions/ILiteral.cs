namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface ILiteral
    /// <para>
    ///     Literals are used to describe positive and negative predicates and goals, as well as effects.
    /// </para>
    /// </summary>
    public interface ILiteral<out T> : IAtomicFormula<T>
    {
        /// <summary>
        /// Determines if the atomic is positive.
        /// </summary>
        /// <value><c>true</c> if the atomic is positive.</value>
        bool Positive { get; }
    }
}
