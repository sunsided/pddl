using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Domains;

namespace PDDL.PDDL12.Model.DomainElements
{
    /// <summary>
    /// Class ConstantsDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ConstantsDefinition : IDomainConstantsDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantsDefinition"/> class.
        /// </summary>
        /// <param name="constants">The types.</param>
        /// <exception cref="ArgumentNullException">The value of 'constants' cannot be null. </exception>
        public ConstantsDefinition(IReadOnlyList<IConstant> constants)
        {
            Constants = constants ?? throw new ArgumentNullException(nameof(constants), "The value cannot be null.");
        }

        /// <summary>
        /// Gets the constants definitions.
        /// </summary>
        /// <value>The constants.</value>
        public IReadOnlyList<IConstant> Constants { get; }
    }
}
