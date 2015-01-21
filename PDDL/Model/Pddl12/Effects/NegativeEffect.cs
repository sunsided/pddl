using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Effects
{
    /// <summary>
    /// Class NegativeEffect.
    /// </summary>
    public class NegativeEffect : EffectBase, IPositiveEffect
    {
        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        public IAtomicFormula Effects { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NegativeEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public NegativeEffect([NotNull] IAtomicFormula effects)
            : base(ListType.Remove)
        {
            if (ReferenceEquals(effects, null)) throw new ArgumentNullException("effects", "effects must not be null");
            Effects = effects;
        }
    }
}
