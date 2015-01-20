using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Types
{
    /// <summary>
    /// Class Typed. This class cannot be inherited.
    /// </summary>
    public sealed class Typed : TypeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Typed" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null. </exception>
        /// <exception cref="ArgumentException">The type name must not be empty</exception>
        public Typed([NotNull] string name) : base(name)
        {
        }
    }
}
