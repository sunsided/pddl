using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class Literal.
    /// </summary>
    internal sealed class Literal<T> : AtomicFormula<T>, ILiteral<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Literal{T}" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="positive">if set to <see langword="true" />, the atomic formula is positive.</param>
        public Literal(IName name, IReadOnlyList<T> parameters, bool positive)
            : base(name, parameters)
        {
            Positive = positive;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Literal{T}" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="positive">if set to <see langword="true" />, the atomic formula is positive.</param>
        public Literal(IName name, bool positive)
            : base(name)
        {
            Positive = positive;
        }

        /// <summary>
        /// Determines if the atomic is positive.
        /// </summary>
        /// <value><c>true</c> if the atomic is positive.</value>
        public bool Positive { get; }
    }
}
