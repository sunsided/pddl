using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.Pddl12.Types;

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
        /// Gets the types.
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
        IReadOnlyList<IConstant> Constants { get; }
    }
}
