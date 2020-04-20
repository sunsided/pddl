using System.Collections.Generic;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Abstractions.Variables;

namespace PDDL.PDDL12.Abstractions
{
    /// <summary>
    /// Interface IAxiom
    /// </summary>
    public interface IAxiom : IDomainStructureElement
    {
        /// <summary>
        /// Gets the variables.
        /// </summary>
        /// <value>The variables.</value>
        IReadOnlyList<IVariableDefinition> Variables { get; }

        /// <summary>
        /// Gets the context.
        /// </summary>
        /// <value>The context.</value>
        IGoalDescription Context { get; }

        /// <summary>
        /// Gets the implication.
        /// </summary>
        /// <value>The implication.</value>
        ILiteral<ITerm> Implication { get; }
    }
}
