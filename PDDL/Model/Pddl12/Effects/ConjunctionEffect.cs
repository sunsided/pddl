using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Effects
{
    /// <summary>
    /// Class ConjunctionEffect.
    /// </summary>
    public class ConjunctionEffect : EffectBase, IConjunctionEffect
    {
        /// <summary>
        /// Gets the effects.
        /// </summary>
        /// <value>The effects.</value>
        public IReadOnlyList<IEffect> Effects { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConjunctionEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public ConjunctionEffect([NotNull] IReadOnlyList<IEffect> effects)
            : base(ListType.Indifferent)
        {
            if (ReferenceEquals(effects, null)) throw new ArgumentNullException("effects", "effects must not be null");
            Effects = effects;
        }
    }
}
