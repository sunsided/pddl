using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Types
{
    /// <summary>
    /// Class CustomType. This class cannot be inherited.
    /// </summary>
    public sealed class CustomType : TypeBase, IPlainType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomType" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null. </exception>
        /// <exception cref="ArgumentException">The type name must not be empty</exception>
        public CustomType([NotNull] string name) : base(name)
        {
        }
    }
}
