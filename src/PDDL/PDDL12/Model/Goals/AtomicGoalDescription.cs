using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Goals;

namespace PDDL.PDDL12.Model.Goals
{
    /// <summary>
    /// Class AtomicGoalDescription.
    /// </summary>
    internal sealed class AtomicGoalDescription : GoalBase, IAtomicGoalDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicGoalDescription" /> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <exception cref="System.ArgumentNullException">condition;condition must not be null</exception>
        /// <exception cref="ArgumentNullException">The value of 'condition' cannot be null.</exception>
        public AtomicGoalDescription(IAtomicFormula<ITerm> condition)
        {
            Condition = condition ?? throw new ArgumentNullException(nameof(condition), "condition must not be null");
        }

        /// <summary>
        /// Gets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public IAtomicFormula<ITerm> Condition { get; }

        /// <summary>
        /// Gets the kind of goal.
        /// </summary>
        /// <value>The kind.</value>
        public override GoalKind Kind => GoalKind.Atomic;
    }
}
