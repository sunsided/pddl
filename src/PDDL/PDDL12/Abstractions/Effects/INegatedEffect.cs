namespace PDDL.PDDL12.Abstractions.Effects
{
    /// <summary>
    /// Interface INegatedEffect
    /// <para>
    ///     Note that negative effects must be applied before positive effects.
    /// </para>
    /// </summary>
    public interface INegatedEffect : IEffect
    {
        /// <summary>
        /// Gets the negated effect.
        /// </summary>
        /// <value>The negated effect.</value>
        IAtomicFormula<ITerm> Effects { get; }
    }
}
