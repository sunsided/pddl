namespace PDDL.PDDL12.Abstractions.Effects
{
    /// <summary>
    /// Interface IRegularEffect
    /// <para>
    ///     Note that positive effects must be applied after negative effects.
    /// </para>
    /// </summary>
    public interface IRegularEffect : IEffect
    {
        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        IAtomicFormula<ITerm> Effects { get; }
    }
}
