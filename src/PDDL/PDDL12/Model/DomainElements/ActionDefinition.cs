using System;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Domains;

namespace PDDL.PDDL12.Model.DomainElements
{
    /// <summary>
    /// Class ActionDefinition. This class cannot be inherited.
    /// </summary>
    internal sealed class ActionDefinition : IDomainActionElement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDefinition"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The value of 'actions' cannot be null. </exception>
        public ActionDefinition(IAction action)
        {
            Action = action ?? throw new ArgumentNullException(nameof(action), "The value cannot be null.");
        }

        /// <summary>
        /// Gets the action definition.
        /// </summary>
        /// <value>The action.</value>
        public IAction Action { get; }
    }
}
