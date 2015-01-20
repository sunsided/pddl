using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IDomain
    /// </summary>
    public interface IDomain
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        IName Name { get; }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        [NotNull]
        IReadOnlyList<IRequirement> Requirements { get; }

        /// <summary>
        /// Gets the type definitions.
        /// </summary>
        /// <remarks>Uses the <c>:typing</c> requirement.</remarks>
        /// <value>The types.</value>
        [NotNull]
        IReadOnlyList<IType> Types { get; }

        /// <summary>
        /// Gets the constants.
        /// </summary>
        /// <value>The constants.</value>
        [NotNull]
        IReadOnlyList<IVariable> Constants { get; }

        /// <summary>
        /// Gets the predicate definitions.
        /// </summary>
        /// <value>The predicates.</value>
        [NotNull]
        IReadOnlyList<IAtomicFormula> Predicates { get; }

        /// <summary>
        /// Gets the timeless literals.
        /// </summary>
        /// <value>The timeless literals.</value>
        [NotNull]
        IReadOnlyList<ILiteral> Timeless { get; }
    }
}
