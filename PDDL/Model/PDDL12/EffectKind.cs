namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class ListType.
    /// </summary>
    public enum EffectKind
    {
        /// <summary>
        /// The effect is negated. This is typically the
        /// case with the remove list.
        /// </summary>
        Negated = -1,
        
        /// <summary>
        /// No effect
        /// </summary>
        None = 0,
        
        /// <summary>
        /// The effect is added.
        /// </summary>
        Regular = 1,

        /// <summary>
        /// This is a composite effect.
        /// </summary>
        Conjunction = 1
    }
}
