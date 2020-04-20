using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Goals;

namespace PDDL.PDDL12.Model.Goals
{
    /// <summary>
    /// Class LiteralGoalDescription.
    /// </summary>
    internal sealed class LiteralGoalDescription : GoalBase, ILiteralGoalDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralGoalDescription" /> class.
        /// </summary>
        /// <param name="literal">The literal.</param>
        /// <exception cref="ArgumentNullException">The value of 'literal' cannot be null.</exception>
        public LiteralGoalDescription(ILiteral<ITerm> literal)
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
