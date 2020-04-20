using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Types;

namespace PDDL.PDDL12.Model.Types
{
    /// <summary>
    /// Class EitherType. This class cannot be inherited.
    /// </summary>
    internal sealed class EitherType : IEitherType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EitherType"/> class.
        /// </summary>
        /// <param name="types">The types.</param>
        /// <exception cref="ArgumentNullException">The value of 'types' cannot be null. </exception>
        /// <exception cref="ArgumentException">the type lust must contain of at least one type</exception>
        public EitherType(IReadOnlyList<IType> types)
        {
            if (ReferenceEquals(types, null)) throw new ArgumentNullException(nameof(types), "types must not be null");
            if (types.Count < 1) throw new ArgumentException("the type lust must contain of at least one type", nameof(types));
            Types = types;
        }

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        public IReadOnlyList<IType> Types { get; }

        /// <summary>
        /// Gets the type flavor.
        /// </summary>
        /// <value>The flavor.</value>
        public TypeKind Kind => TypeKind.Either;
    }
}
