﻿using System;
using PDDL.PDDL12.Abstractions;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class Object.
    /// </summary>
    internal sealed class Object : IObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Object"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'type' cannot be null. </exception>
        public Object(IName name, IType type)
        {
            Value = name ?? throw new ArgumentNullException(nameof(name), "name must not be null");
            Type = type ?? throw new ArgumentNullException(nameof(type), "type must not be null");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Object" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null.</exception>
        public Object(IName name)
            : this(name, Types.DefaultType.Default)
        {
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Value { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public IType Type { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => $"{Value} - {Type}";
    }
}
