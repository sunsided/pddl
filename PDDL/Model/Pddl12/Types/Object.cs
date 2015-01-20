using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Types
{
    /// <summary>
    /// Class Object. This class cannot be inherited.
    /// <para>
    ///     This is the implicit type of all instances if no
    ///     other type is explicitly defined.
    /// </para>
    /// </summary>
    public sealed class Object : TypeBase
    {
        /// <summary>
        /// The default instance
        /// </summary>
        [NotNull]
        private static readonly Object _default = new Object();

        /// <summary>
        /// Returns the default instance of the <see cref="Object"/>
        /// </summary>
        /// <value>The default.</value>
        [NotNull]
        public static Object Default { get { return _default; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Object"/> class.
        /// </summary>
        public Object() : base("Object")
        { }
    }
}
