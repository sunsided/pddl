namespace PDDL.Model.PDDL12.Effects
{
    /// <summary>
    /// Class EffectBase.
    /// </summary>
    public abstract class EffectBase : IEffect
    {
        /// <summary>
        /// Gets the list type.
        /// </summary>
        /// <value>The list type.</value>
        public EffectKind Type { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EffectBase"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        protected EffectBase(EffectKind type)
        {
            Type = type;
        }
    }
}
