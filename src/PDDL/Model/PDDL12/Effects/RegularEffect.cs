using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Effects
{
    /// <summary>
    /// Class RegularEffect.
    /// </summary>
    public class RegularEffect : EffectBase, IRegularEffect
    {
        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        public IAtomicFormula<ITerm> Effects { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegularEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public RegularEffect([NotNull] IAtomicFormula<ITerm> effects)
            : base(EffectKind.Regular)
        {
            Effects = effects ?? throw new ArgumentNullException(nameof(effects), "effects must not be null");
        }
    }
}
