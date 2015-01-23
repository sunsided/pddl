using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Effects
{
    /// <summary>
    /// Class PositiveEffect.
    /// </summary>
    public class PositiveEffect : EffectBase, IPositiveEffect
    {
        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        public IAtomicFormula<ITerm> Effects { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PositiveEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public PositiveEffect([NotNull] IAtomicFormula<ITerm> effects)
            : base(ListType.Add)
        {
            if (ReferenceEquals(effects, null)) throw new ArgumentNullException("effects", "effects must not be null");
            Effects = effects;
        }
    }
}
