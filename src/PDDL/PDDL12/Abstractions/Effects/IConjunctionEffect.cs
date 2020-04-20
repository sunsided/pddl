using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions.Effects
{
    /// <summary>
    /// Interface IConjunctionEffect
    /// <para>
    ///     Combines multiple effects using an <c>and</c> relationship.
    /// </para>
    /// </summary>
    public interface IConjunctionEffect : IEffect
    {
        /// <summary>
        /// Gets the effects.
        /// </summary>
        /// <value>The effects.</value>
        IReadOnlyList<IEffect> Effects { get; }
    }
}
