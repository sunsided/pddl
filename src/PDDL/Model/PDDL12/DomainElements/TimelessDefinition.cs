using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class TimelessDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class TimelessDefinition : IDomainTimelessDefinition
    {
        /// <summary>
        /// Gets the timeless definitions.
        /// </summary>
        /// <value>The timeless.</value>
        public IReadOnlyList<ILiteral<IName>> Timeless { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimelessDefinition"/> class.
        /// </summary>
        /// <param name="timeless">The timeless literals.</param>
        /// <exception cref="ArgumentNullException">The value of 'timeless' cannot be null. </exception>
        public TimelessDefinition([NotNull] IReadOnlyList<ILiteral<IName>> timeless)
        {
            Timeless = timeless ?? throw new ArgumentNullException(nameof(timeless), "The value cannot be null.");
        }
    }
}
