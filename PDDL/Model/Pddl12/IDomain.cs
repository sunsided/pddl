﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IDomain
    /// </summary>
    public interface IDomain
    {
        // TODO: Extension definition is missing

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        IName Name { get; }

        /// <summary>
        /// Gets the names of the extended domains.
        /// </summary>
        /// <value>The types.</value>
        [NotNull]
        IReadOnlyList<IName> Extends { get; }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        [NotNull]
        IReadOnlyList<IRequirement> Requirements { get; }

        /// <summary>
        /// Gets the type definitions.
        /// </summary>
        /// <remarks>Uses the <c>:typing</c> requirement.</remarks>
        /// <value>The types.</value>
        [NotNull]
        IReadOnlyList<IType> Types { get; }

        /// <summary>
        /// Gets the constants.
        /// </summary>
        /// <value>The constants.</value>
        [NotNull]
        IReadOnlyList<IConstant> Constants { get; }

        /// <summary>
        /// Gets the predicate definitions.
        /// </summary>
        /// <value>The predicates.</value>
        [NotNull]
        IReadOnlyList<IAtomicFormulaSkeleton> Predicates { get; }

        /// <summary>
        /// Gets the timeless literals.
        /// </summary>
        /// <value>The timeless literals.</value>
        [NotNull]
        IReadOnlyList<ILiteral<IName>> Timeless { get; }

        /// <summary>
        /// Gets the safety constraints.
        /// </summary>
        /// <value>The safety constraints.</value>
        [NotNull]
        IReadOnlyList<IGoalDescription> Safety { get; }

        /// <summary>
        /// Gets the domain variables.
        /// </summary>
        /// <value>The domain variables.</value>
        [NotNull]
        IReadOnlyList<IDomainVariable> Variables { get; }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        [NotNull]
        IReadOnlyList<IAction> Actions { get; }

        /// <summary>
        /// Gets or sets the axioms.
        /// </summary>
        /// <value>The axioms.</value>
        [NotNull]
        IReadOnlyList<IAxiom> Axioms { get; }
    }
}
