using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Class Domain.
    /// </summary>
    public class Domain : IDomain
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Name { get; private set; }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        public IReadOnlyList<IRequirement> Requirements { get; private set; }

        /// <summary>
        /// Gets the type definitions.
        /// </summary>
        /// <value>The types.</value>
        /// <remarks>Uses the <c>:typing</c> requirement.</remarks>
        public IReadOnlyList<IType> Types { get; private set; }

        /// <summary>
        /// Gets the constants.
        /// </summary>
        /// <value>The constants.</value>
        public IReadOnlyList<IConstant> Constants { get; private set; }

        /// <summary>
        /// Gets the predicate definitions.
        /// </summary>
        /// <value>The predicates.</value>
        public IReadOnlyList<IAtomicFormulaSkeleton> Predicates { get; private set; }

        /// <summary>
        /// Gets the timeless literals.
        /// </summary>
        /// <value>The timeless literals.</value>
        public IReadOnlyList<ILiteral> Timeless { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Domain"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="requirements">The requirements.</param>
        /// <param name="types">The types.</param>
        /// <param name="constants">The constants.</param>
        /// <param name="predicates">The predicates.</param>
        /// <param name="timeless">The timeless.</param>
        /// <exception cref="ArgumentNullException">None of the arguments may be null. </exception>
        public Domain([NotNull] IName name, [NotNull] IReadOnlyList<IRequirement> requirements, [NotNull] IReadOnlyList<IType> types, [NotNull] IReadOnlyList<IConstant> constants, [NotNull] IReadOnlyList<IAtomicFormulaSkeleton> predicates, [NotNull] IReadOnlyList<ILiteral> timeless)
        {
            if (ReferenceEquals(name, null)) throw new ArgumentNullException("name", "name must not be null");
            if (ReferenceEquals(requirements, null)) throw new ArgumentNullException("requirements", "requirements must not be null");
            if (ReferenceEquals(types, null)) throw new ArgumentNullException("types", "types must not be null");
            if (ReferenceEquals(constants, null)) throw new ArgumentNullException("constants", "constants must not be null");
            if (ReferenceEquals(predicates, null)) throw new ArgumentNullException("predicates", "predicates must not be null");
            if (ReferenceEquals(timeless, null)) throw new ArgumentNullException("timeless", "timeless must not be null");

            Name = name;
            Requirements = requirements;
            Types = types;
            Constants = constants;
            Predicates = predicates;
            Timeless = timeless;
        }
    }
}
