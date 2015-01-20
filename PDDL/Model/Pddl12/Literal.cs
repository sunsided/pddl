﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Class Literal.
    /// </summary>
    public class Literal : AtomicFormula, ILiteral
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicFormula" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="positive">if set to <see langword="true" />, the atomic formula is positive.</param>
        public Literal([NotNull] IName name, [NotNull] IReadOnlyList<IVariable> parameters, bool positive)
            : base(name, parameters)
        {
            Positive = positive;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicFormula" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="positive">if set to <see langword="true" />, the atomic formula is positive.</param>
        public Literal([NotNull] IName name, bool positive)
            : base(name)
        {
            Positive = positive;
        }

        /// <summary>
        /// Determines if the atomic is positive.
        /// </summary>
        /// <value><c>true</c> if the atomic is positive.</value>
        public bool Positive { get; private set; }
    }
}
