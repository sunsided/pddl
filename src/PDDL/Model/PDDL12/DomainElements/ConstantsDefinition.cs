using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class ConstantsDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ConstantsDefinition : IDomainConstantsDefinition
    {
        /// <summary>
        /// Gets the constants definitions.
        /// </summary>
        /// <value>The constants.</value>
        public IReadOnlyList<IConstant> Constants { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantsDefinition"/> class.
        /// </summary>
        /// <param name="constants">The types.</param>
        /// <exception cref="ArgumentNullException">The value of 'constants' cannot be null. </exception>
        public ConstantsDefinition([NotNull] IReadOnlyList<IConstant> constants)
        {
            Constants = constants ?? throw new ArgumentNullException(nameof(constants), "The value cannot be null.");
        }
    }
}
