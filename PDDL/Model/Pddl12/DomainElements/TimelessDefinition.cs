using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class TimelessDefinition. This class cannot be inherited.
    /// </summary>
    public sealed class TimelessDefinition : IDomainTimelessDefinition
    {
        /// <summary>
        /// Gets the timeless definitions.
        /// </summary>
        /// <value>The timeless.</value>
        [NotNull]
        public IReadOnlyList<ILiteral<IName>> Timeless { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimelessDefinition"/> class.
        /// </summary>
        /// <param name="timeless">The timeless literals.</param>
        /// <exception cref="ArgumentNullException">The value of 'timeless' cannot be null. </exception>
        public TimelessDefinition([NotNull] IReadOnlyList<ILiteral<IName>> timeless)
        {
            if (ReferenceEquals(timeless, null)) throw new ArgumentNullException("timeless", "The value cannot be null.");
            Timeless = timeless;
        }
    }
}
