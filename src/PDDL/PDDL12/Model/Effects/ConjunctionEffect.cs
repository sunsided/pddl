using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Effects;

namespace PDDL.PDDL12.Model.Effects
{
    /// <summary>
    /// Class ConjunctionEffect.
    /// </summary>
    internal sealed class ConjunctionEffect : EffectBase, IConjunctionEffect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConjunctionEffect"/> class.
        /// </summary>
        /// <param name="effects">The effects.</param>
        /// <exception cref="ArgumentNullException">The value of 'effects' cannot be null. </exception>
        public ConjunctionEffect(IReadOnlyList<IEffect> effects)
            : base(EffectKind.Conjunction)
        {
            Effects = effects ?? throw new ArgumentNullException(nameof(effects), "effects must not be null");
        }

        /// <summary>
        /// Gets the effects.
        /// </summary>
        /// <value>The effects.</value>
        public IReadOnlyList<IEffect> Effects { get; }
    }
}
