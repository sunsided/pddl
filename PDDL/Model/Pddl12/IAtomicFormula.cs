using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IAtomicFormula
    /// <para>
    ///     Atomic formulae are used to describe (ground) predicates
    /// </para>
    /// </summary>
    public interface IAtomicFormula
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        IName Name { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        [NotNull]
        IReadOnlyList<ITerm> Parameters { get; }
    }
}
