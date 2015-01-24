using System;
using System.Collections.Generic;

namespace PDDL.Model.PDDL12.Types
{
    /// <summary>
    /// Class EitherType. This class cannot be inherited.
    /// </summary>
    internal sealed class EitherType : IEitherType
    {
        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        public IReadOnlyList<IType> Types { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EitherType"/> class.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <exception cref="ArgumentNullException">The value of 'types' cannot be null. </exception>
        /// <exception cref="ArgumentException">the type lust must contain of at least one type</exception>
        public EitherType(IReadOnlyList<IType> types)
        {
            if (ReferenceEquals(types, null)) throw new ArgumentNullException("types", "types must not be null");
            if (types.Count < 1) throw new ArgumentException("the type lust must contain of at least one type", "types");
            Types = types;
        }
    }
}
