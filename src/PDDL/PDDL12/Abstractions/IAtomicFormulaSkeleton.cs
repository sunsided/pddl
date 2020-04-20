using System.Collections.Generic;
using PDDL.PDDL12.Abstractions.Variables;

namespace PDDL.PDDL12.Abstractions
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
        IPredicate Name { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        IReadOnlyList<IVariableDefinition> Parameters { get; }
    }
}
