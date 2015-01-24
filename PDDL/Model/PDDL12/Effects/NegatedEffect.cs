using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Effects
{
    /// <summary>
    /// Class NegativeEffect.
    /// </summary>
    public class NegatedEffect : EffectBase, INegatedEffect
    {
        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        public IAtomicFormula<ITerm> Effects { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NegatedEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public NegatedEffect([NotNull] IAtomicFormula<ITerm> effects)
            : base(EffectKind.Negated)
        {
            if (ReferenceEquals(effects, null)) throw new ArgumentNullException("effects", "effects must not be null");
            Effects = effects;
        }
    }
}
