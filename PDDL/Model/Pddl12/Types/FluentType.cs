using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Types
{
    /// <summary>
    /// Class FluentType. This class cannot be inherited.
    /// </summary>
    public sealed class FluentType : TypeBase, IFluentType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentType" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null. </exception>
        public FluentType([NotNull] IName name)
            : base(name)
        {
        }
    }
}
