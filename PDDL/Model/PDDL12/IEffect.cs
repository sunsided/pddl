using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Interface IEffect
    /// </summary>
    public interface IEffect
    {
        /// <summary>
        /// Gets the list type.
        /// </summary>
        /// <value>The list type.</value>
        ListType Type { get; }
    }

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
        [NotNull]
        IReadOnlyList<IEffect> Effects { get; }
    }

    /// <summary>
    /// Interface IRegularEffect
    /// <para>
    ///     Note that positive effects must be applied after negative effects.
    /// </para>
    /// </summary>
    public interface IRegularEffect : IEffect
    {
        /// <summary>
        /// Gets the effect.
        /// </summary>
        /// <value>The effect.</value>
        [NotNull]
        IAtomicFormula<ITerm> Effects { get; }
    }

    /// <summary>
    /// Interface INegatedEffect
    /// <para>
    ///     Note that negative effects must be applied before positive effects.
    /// </para>
    /// </summary>
    public interface INegatedEffect : IEffect
    {
        /// <summary>
        /// Gets the negated effect.
        /// </summary>
        /// <value>The negated effect.</value>
        [NotNull]
        IAtomicFormula<ITerm> Effects { get; }
    }
}
