using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Goals
{
    /// <summary>
    /// Class LiteralGoalDescription.
    /// </summary>
    public class LiteralGoalDescription : GoalBase, ILiteralGoalDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralGoalDescription" /> class.
        /// </summary>
        /// <param name="literal">The literal.</param>
        /// <exception cref="ArgumentNullException">The value of 'literal' cannot be null.</exception>
        public LiteralGoalDescription([NotNull] ILiteral<ITerm> literal)
        {
            Literal = literal ?? throw new ArgumentNullException(nameof(literal), "literal must not be null");
        }

        /// <summary>
        /// Gets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public ILiteral<ITerm> Literal { get; }

        /// <summary>
        /// Gets the kind of goal.
        /// </summary>
        /// <value>The kind.</value>
        public override GoalKind Kind => GoalKind.Literal;
    }
}
