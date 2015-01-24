using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Types
{
    /// <summary>
    /// Class FluentType. This class cannot be inherited.
    /// </summary>
    public sealed class FluentType : IFluentType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentType" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="ArgumentNullException">The value of 'type' cannot be null. </exception>
        public FluentType([NotNull] IType type)
        {
            if (ReferenceEquals(type, null)) throw new ArgumentNullException("type", "type must not be null");
            Type = type;
        }

        /// <summary>
        /// Gets the fluent type.
        /// </summary>
        /// <value>The fluent type.</value>
        public IType Type { get; private set; }
    }
}
