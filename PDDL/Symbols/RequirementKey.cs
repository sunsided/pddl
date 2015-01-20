using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Symbols
{
    /// <summary>
    /// Class RequirementKey. This class cannot be inherited.
    /// </summary>
    sealed class RequirementKey : Symbol
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [NotNull]
        public string Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementKey" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> was <see langword="null"/></exception>
        /// <exception cref="ArgumentException"><paramref name="value"/> is an invalid requirement</exception>
        public RequirementKey([NotNull] string value)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException("value", "value was null");
            if (!IsValid(value)) throw new ArgumentException("value is an invalid requirement: " + value, "value");
            Value = value;
        }

        /// <summary>
        /// The set of valid requirements
        /// </summary>
        [NotNull]
        private static readonly HashSet<string> _validRequirements = new HashSet<string>(new []
                                                                                        {
                                                                                            ":strips",
                                                                                            ":typing",
                                                                                            ":disjunctive-preconditions",
                                                                                            ":equality",
                                                                                            ":existential-preconditions",
                                                                                            ":universal-preconditions",
                                                                                            ":quantified-preconditions",
                                                                                            ":conditional-effects",
                                                                                            ":action-expansions",
                                                                                            ":foreach-expansions",
                                                                                            ":dag-expansions",
                                                                                            ":domain-axioms",
                                                                                            ":subgoal-through-axioms",
                                                                                            ":safety-constraints",
                                                                                            ":expression-evaluation",
                                                                                            ":fluents",
                                                                                            ":open-world",
                                                                                            ":true-negation",
                                                                                            ":adl",
                                                                                            ":ucpop"
                                                                                        });

        /// <summary>
        /// Determines whether the specified value is a valid requirement key.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns><see langword="true" /> if the specified value is valid; otherwise, <see langword="false" />.</returns>
        [Pure]
        public static bool IsValid([CanBeNull] string value)
        {
            return _validRequirements.Contains(value);
        }
    }
}
