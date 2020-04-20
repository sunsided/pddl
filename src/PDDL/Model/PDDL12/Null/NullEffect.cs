using JetBrains.Annotations;
using PDDL.Model.PDDL12.Effects;

namespace PDDL.Model.PDDL12.Null
{
    /// <summary>
    /// Class NullEffect.
    /// </summary>
    public sealed class NullEffect : EffectBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullEffect"/> class.
        /// </summary>
        public NullEffect()
            : base(EffectKind.None)
        {
        }

        /// <summary>
        /// Returns the default instance of the <see cref="NullEffect"/>
        /// </summary>
        /// <value>The default.</value>
        [NotNull]
        public static NullEffect Default { get; } = new NullEffect();
    }
}
