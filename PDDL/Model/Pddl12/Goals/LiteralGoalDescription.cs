using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Goals
{
    /// <summary>
    /// Class LiteralGoalDescription.
    /// </summary>
    internal sealed class LiteralGoalDescription : GoalBase, ILiteralGoalDescription
    {
        /// <summary>
        /// Gets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public ILiteral<ITerm> Literal { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralGoalDescription" /> class.
        /// </summary>
        /// <param name="literal">The literal.</param>
        /// <exception cref="ArgumentNullException">The value of 'literal' cannot be null.</exception>
        public LiteralGoalDescription([NotNull] ILiteral<ITerm> literal)
        {
            if (ReferenceEquals(literal, null)) throw new ArgumentNullException("literal", "literal must not be null");
            Literal = literal;
        }
    }
}
