﻿using System;
using PDDL.PDDL12.Abstractions;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class Predicate. This class cannot be inherited.
    /// </summary>
    internal sealed class Predicate : Name, IPredicate
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Predicate"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        /// <exception cref="ArgumentException">value must not be empty or whitespace only and not contain invalid characters</exception>
        public Predicate(string value)
            : base(value)
        {
        }
    }
}
