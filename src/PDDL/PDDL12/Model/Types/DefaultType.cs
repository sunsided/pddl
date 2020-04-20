using PDDL.PDDL12.Abstractions.Types;

namespace PDDL.PDDL12.Model.Types
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
        /// Initializes a new instance of the <see cref="DefaultType"/> class.
        /// </summary>
        private DefaultType() : base(new Name("object"))
        { }

        /// <summary>
        /// Returns the default instance of the <see cref="DefaultType"/>
        /// </summary>
        /// <value>The default.</value>
        public static DefaultType Default { get; } = new DefaultType();

        /// <summary>
        /// Gets the type flavor.
        /// </summary>
        /// <value>The flavor.</value>
        public override TypeKind Kind => TypeKind.Default;
    }
}
