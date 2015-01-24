using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Types
{
    /// <summary>
    /// Class CustomType. This class cannot be inherited.
    /// </summary>
    internal sealed class CustomType : TypeBase, ICustomType
    {
        /// <summary>
        /// Gets or sets the parent type.
        /// </summary>
        /// <value>The parent type.</value>
        [NotNull]
        public IType Parent { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomType" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parent">The parent.</param>
        /// <exception cref="System.ArgumentNullException">parent;parent type must not be null</exception>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null.</exception>
        public CustomType([NotNull] IName name, [NotNull] IType parent)
            : base(name)
        {
            if (ReferenceEquals(parent, null)) throw new ArgumentNullException("parent", "parent type must not be null");
            Parent = parent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomType" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null. </exception>
        /// <exception cref="ArgumentException">The type name must not be empty</exception>
        public CustomType([NotNull] IName name)
            : this(name, DefaultType.Default)
        {
        }
    }
}
