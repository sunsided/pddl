using System.Collections.Generic;

namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface IAtomicFormula
    /// <para>
    ///     Atomic formulae are used to describe (ground) predicates
    /// </para>
    /// </summary>
    public interface IAtomicFormula<out T>
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        IName Name { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        IReadOnlyList<T> Parameters { get; }
    }
}
