﻿using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Types;

namespace PDDL.PDDL12.Model.Types
{
    /// <summary>
    /// Class FluentType. This class cannot be inherited.
    /// </summary>
    internal sealed class FluentType : IFluentType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FluentType" /> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="ArgumentNullException">The value of 'type' cannot be null. </exception>
        public FluentType(IType type)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type), "type must not be null");
        }

        /// <summary>
        /// Gets the fluent type.
        /// </summary>
        /// <value>The fluent type.</value>
        public IType Type { get; }

        /// <summary>
        /// Gets the type flavor.
        /// </summary>
        /// <value>The flavor.</value>
        public TypeKind Kind => TypeKind.Fluent;
    }
}
