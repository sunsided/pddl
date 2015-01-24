namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Enum TypeFlavor
    /// </summary>
    public enum TypeKind
    {
        /// <summary>
        /// The default type
        /// </summary>
        Default,

        /// <summary>
        /// A user-defined type
        /// </summary>
        UserDefined,

        /// <summary>
        /// Multiple valid types
        /// </summary>
        Either,

        /// <summary>
        /// A fluent type
        /// </summary>
        Fluent
    }
}
