using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IAtomicFormulaSkeleton
    /// <para>
    ///     Atomic formulae are used to describe predicates and goals, as well as effects.
    /// </para>
    /// </summary>
    public interface IAtomicFormulaSkeleton
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        IPredicate Name { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        [NotNull]
        IReadOnlyList<IVariableDefinition> Parameters { get; }
    }
}
