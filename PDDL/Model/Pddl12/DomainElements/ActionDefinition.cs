using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.DomainElements
{
    /// <summary>
    /// Class ActionDefinition. This class cannot be inherited.
    /// </summary>
    public sealed class ActionDefinition : IDomainActionElement
    {
        /// <summary>
        /// Gets the action definition.
        /// </summary>
        /// <value>The action.</value>
        [NotNull]
        public IAction Action { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionDefinition"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        /// <exception cref="ArgumentNullException">The value of 'actions' cannot be null. </exception>
        public ActionDefinition([NotNull] IAction action)
        {
            if (ReferenceEquals(action, null)) throw new ArgumentNullException("action", "The value cannot be null.");
            Action = action;
        }
    }
}
