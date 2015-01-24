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
        public IAtomicFormula<ITerm> Effects { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegularEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public RegularEffect([NotNull] IAtomicFormula<ITerm> effects)
            : base(ListType.Add)
        {
            if (ReferenceEquals(effects, null)) throw new ArgumentNullException("effects", "effects must not be null");
            Effects = effects;
        }
    }
}
