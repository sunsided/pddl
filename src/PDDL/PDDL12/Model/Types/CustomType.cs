using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Types;

namespace PDDL.PDDL12.Model.Types
{
    /// <summary>
    /// Class CustomType. This class cannot be inherited.
    /// </summary>
    internal sealed class CustomType : TypeBase, ICustomType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomType" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parent">The parent.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null.</exception>
        public CustomType(IName name, IType parent)
            : base(name)
        {
            Parent = parent ?? throw new ArgumentNullException(nameof(parent), "parent type must not be null");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomType" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null. </exception>
        public CustomType(IName name)
            : this(name, DefaultType.Default)
        {
        }

        /// <summary>
        /// Gets or sets the parent type.
        /// </summary>
        /// <value>The parent type.</value>
        public IType Parent { get; }

        /// <summary>
        /// Gets the type flavor.
        /// </summary>
        /// <value>The flavor.</value>
        public override TypeKind Kind => Name.Value.Equals("object", StringComparison.OrdinalIgnoreCase) ? TypeKind.Default : TypeKind.UserDefined;
    }
}
