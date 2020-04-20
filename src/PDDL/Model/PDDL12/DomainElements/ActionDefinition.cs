using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12.DomainElements
{
    /// <summary>
    /// Class ActionDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ActionDefinition : IDomainActionElement
    {
        /// <summary>
        /// Gets the action definition.
        /// </summary>
        /// <value>The action.</value>
        public IAction Action { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDefinition"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The value of 'actions' cannot be null. </exception>
        public ActionDefinition([NotNull] IAction action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action), "The value cannot be null.");
        }
    }
}
