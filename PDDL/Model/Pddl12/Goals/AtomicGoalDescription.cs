using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.Goals
{
    /// <summary>
    /// Class AtomicGoalDescription.
    /// </summary>
    public class AtomicGoalDescription : GoalBase, IAtomicGoalDescription
    {
        /// <summary>
        /// Gets the condition.
        /// </summary>
        /// <value>The condition.</value>
        public IAtomicFormula<ITerm> Condition { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicGoalDescription" /> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <exception cref="System.ArgumentNullException">condition;condition must not be null</exception>
        /// <exception cref="ArgumentNullException">The value of 'condition' cannot be null.</exception>
        public AtomicGoalDescription([NotNull] IAtomicFormula<ITerm> condition)
        {
            if (ReferenceEquals(condition, null)) throw new ArgumentNullException("condition", "condition must not be null");
            Condition = condition;
        }
    }
}
