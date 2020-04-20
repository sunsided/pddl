using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Domains;

namespace PDDL.PDDL12.Model.DomainElements
{
    /// <summary>
    /// Class TimelessDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class TimelessDefinition : IDomainTimelessDefinition
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimelessDefinition"/> class.
        /// </summary>
        /// <param name="timeless">The timeless literals.</param>
        /// <exception cref="ArgumentNullException">The value of 'timeless' cannot be null. </exception>
        public TimelessDefinition(IReadOnlyList<ILiteral<IName>> timeless)
        {
            Timeless = timeless ?? throw new ArgumentNullException(nameof(timeless), "The value cannot be null.");
        }

        /// <summary>
        /// Gets the timeless definitions.
        /// </summary>
        /// <value>The timeless.</value>
        public IReadOnlyList<ILiteral<IName>> Timeless { get; }
    }
}
