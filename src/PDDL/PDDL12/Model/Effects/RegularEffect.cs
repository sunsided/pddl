using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Effects;

namespace PDDL.PDDL12.Model.Effects
{
    /// <summary>
    /// Class RegularEffect.
    /// </summary>
    internal sealed class RegularEffect : EffectBase, IRegularEffect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegularEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public RegularEffect(IAtomicFormula<ITerm> effects)
            : base(EffectKind.Regular)
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
