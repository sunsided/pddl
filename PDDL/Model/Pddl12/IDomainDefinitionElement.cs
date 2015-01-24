namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Interface IDomainDefinitionElement
    /// </summary>
    public interface IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainExtensionDefinition
    /// </summary>
    public interface IDomainExtensionDefinition : IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainRequireDefinition
    /// </summary>
    public interface IDomainRequireDefinition : IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainTypesDefinition
    /// </summary>
    public interface IDomainTypesDefinition : IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainConstantsDefinition
    /// </summary>
    public interface IDomainConstantsDefinition : IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainVarsDefinition
    /// </summary>
    public interface IDomainVarsDefinition : IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainPredicatesDefinition
    /// </summary>
    public interface IDomainPredicatesDefinition : IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainTimelessDefinition
    /// </summary>
    public interface IDomainTimelessDefinition : IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainSafetyDefinition
    /// </summary>
    public interface IDomainSafetyDefinition : IDomainDefinitionElement
    { }

    /// <summary>
    /// Interface IDomainStructureElement
    /// <para>
    ///     Describes an element that appears within the domain structure.
    /// </para>
    /// </summary>
    public interface IDomainStructureElement : IDomainDefinitionElement
    {
    }
}
