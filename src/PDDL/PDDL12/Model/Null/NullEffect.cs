using PDDL.PDDL12.Abstractions.Effects;
using PDDL.PDDL12.Model.Effects;

namespace PDDL.PDDL12.Model.Null
{
    /// <summary>
    /// Class NullEffect.
    /// </summary>
    internal sealed class NullEffect : EffectBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NullEffect"/> class.
        /// </summary>
        private NullEffect()
            : base(EffectKind.None)
        {
        }

        /// <summary>
        /// Returns the default instance of the <see cref="NullEffect"/>
        /// </summary>
        /// <value>The default.</value>
        public static NullEffect Default { get; } = new NullEffect();
    }
}
