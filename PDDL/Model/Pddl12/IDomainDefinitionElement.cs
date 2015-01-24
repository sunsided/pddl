using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IDomainDefinitionElement
    /// </summary>
    public interface IDomainDefinitionElement
    {
        // intentionally left blank
    }

    /// <summary>
    /// Interface IDomainExtensionDefinition
    /// </summary>
    public interface IDomainExtensionDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the names.
        /// </summary>
        /// <value>The names.</value>
        [NotNull]
        IReadOnlyList<IName> Names { get; }
    }

    /// <summary>
    /// Interface IDomainRequireDefinition
    /// </summary>
    public interface IDomainRequireDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        [NotNull]
        IReadOnlyList<IRequirement> Requirements { get; }
    }

    /// <summary>
    /// Interface IDomainTypesDefinition
    /// </summary>
    public interface IDomainTypesDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the type definitions.
        /// </summary>
        /// <remarks>Uses the <c>:typing</c> requirement.</remarks>
        /// <value>The types.</value>
        [NotNull]
        IReadOnlyList<IType> Types { get; }

    }

    /// <summary>
    /// Interface IDomainConstantsDefinition
    /// </summary>
    public interface IDomainConstantsDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the constants definitions.
        /// </summary>
        /// <value>The constants.</value>
        [NotNull]
        IReadOnlyList<IConstant> Constants { get; }
    }

    /// <summary>
    /// Interface IDomainVarsDefinition
    /// </summary>
    public interface IDomainVarsDefinition : IDomainDefinitionElement
    {
        // TODO: add domain-vars
    }

    /// <summary>
    /// Interface IDomainPredicatesDefinition
    /// </summary>
    public interface IDomainPredicatesDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the predicate definitions.
        /// </summary>
        /// <value>The predicate.</value>
        [NotNull]
        IReadOnlyList<IAtomicFormulaSkeleton> Predicates { get; }
    }

    /// <summary>
    /// Interface IDomainTimelessDefinition
    /// </summary>
    public interface IDomainTimelessDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the timeless definitions.
        /// </summary>
        /// <value>The timeless.</value>
        [NotNull]
        IReadOnlyList<ILiteral<IName>> Timeless { get; }
    }

    /// <summary>
    /// Interface IDomainSafetyDefinition
    /// </summary>
    public interface IDomainSafetyDefinition : IDomainDefinitionElement
    {
        /// <summary>
        /// Gets the safety constraints.
        /// </summary>
        /// <value>The safety constraints.</value>
        [NotNull]
        IReadOnlyList<IGoalDescription> Safety { get; }
    }

    /// <summary>
    /// Interface IDomainStructureElement
    /// <para>
    ///     Describes an element that appears within the domain structure.
    /// </para>
    /// </summary>
    public interface IDomainStructureElement : IDomainDefinitionElement
    {
        // intentionally left blank
    }

    /// <summary>
    /// Interface IDomainActionElement
    /// </summary>
    public interface IDomainActionElement : IDomainStructureElement
    {
        /// <summary>
        /// Gets the action definition.
        /// </summary>
        /// <value>The action.</value>
        [NotNull]
        IAction Action { get; }
    }

    /// <summary>
    /// Interface IDomainActionElement
    /// </summary>
    public interface IDomainAxiomElement : IDomainStructureElement
    {
        /// <summary>
        /// Gets the axiom definition.
        /// </summary>
        /// <value>The axiom.</value>
        [NotNull]
        IAxiom Axiom { get; }
    }
}
