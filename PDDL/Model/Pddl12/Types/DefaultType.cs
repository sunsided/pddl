using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Types
{
    /// <summary>
    /// Class DefaultType. This class cannot be inherited.
    /// <para>
    ///     This is the implicit type of all instances if no
    ///     other type is explicitly defined.
    /// </para>
    /// </summary>
    internal sealed class DefaultType : TypeBase
    {
        /// <summary>
        /// The default instance
        /// </summary>
        [NotNull]
        private static readonly DefaultType _default = new DefaultType();

        /// <summary>
        /// Returns the default instance of the <see cref="DefaultType"/>
        /// </summary>
        /// <value>The default.</value>
        [NotNull]
        public static DefaultType Default { get { return _default; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultType"/> class.
        /// </summary>
        public DefaultType() : base(new Name("object"))
        { }
    }
}
