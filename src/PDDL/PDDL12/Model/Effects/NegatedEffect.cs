using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Effects;

namespace PDDL.PDDL12.Model.Effects
{
    /// <summary>
    /// Class NegativeEffect.
    /// </summary>
    internal sealed class NegatedEffect : EffectBase, INegatedEffect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NegatedEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public NegatedEffect(IAtomicFormula<ITerm> effects)
            : base(EffectKind.Negated)
        {
            Effects = effects ?? throw new ArgumentNullException(nameof(effects), "effects must not be null");
        }

        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        public IAtomicFormula<ITerm> Effects { get; }
    }
}
