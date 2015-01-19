using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Symbols.Keywords
{
    /// <summary>
    /// Class DomainDefinitionKeyword. This class cannot be inherited.
    /// </summary>
    sealed class DomainDefinitionKeyword : Keyword
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainDefinitionKeyword" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> was <see langword="null"/></exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is an invalid requirement</exception>
        public DomainDefinitionKeyword([NotNull] string value)
            : base(value)
        {
            if (!IsValid(value)) throw new ArgumentException("value is an invalid requirement: " + value, "value");
        }

        /// <summary>
        /// The set of valid keyword
        /// </summary>
        [NotNull]
        private static readonly HashSet<string> _validKeywords = new HashSet<string>(new []
                                                                                        {
                                                                                            ":extends",
                                                                                            ":requirements",
                                                                                            ":types",
                                                                                            ":constants",
                                                                                            ":domain-variables",
                                                                                            ":predicates",
                                                                                            ":timeless"
                                                                                        });

        /// <summary>
        /// Determines whether the specified value is a valid keyword.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see langword="true" /> if the specified value is valid; otherwise, <see langword="false" />.</returns>
        [Pure]
        public static bool IsValid([CanBeNull] string value)
        {
            return _validKeywords.Contains(value);
        }
    }
}
