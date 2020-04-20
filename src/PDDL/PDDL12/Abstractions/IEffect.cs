using PDDL.PDDL12.Abstractions.Effects;

namespace PDDL.PDDL12.Abstractions
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
        EffectKind Type { get; }
    }
}
