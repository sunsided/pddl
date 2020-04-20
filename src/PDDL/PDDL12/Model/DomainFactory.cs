using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Abstractions.Variables;
using Sprache;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class Pddl12DomainStructure. This class cannot be inherited.
    /// </summary>
    internal sealed class DomainFactory
    {
        /// <summary>
        /// Creates a <see cref="DomainFactory" /> instance from a mixed sequence of parsed domain structure elements.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="sequence">The sequence.</param>
        /// <returns>Pddl12DomainStructure.</returns>
        /// <exception cref="Sprache.ParseException">
        /// :extends definition occured more than once
        /// or
        /// :requirements definition occured more than once
        /// or
        /// :types definition occured more than once
        /// or
        /// :constants definition occured more than once
        /// or
        /// :predicates definition occured more than once
        /// or
        /// :timeless definition occured more than once
        /// </exception>
        /// <exception cref="System.ArgumentException">Sequence contained unrecognized element</exception>
        /// <exception cref="ArgumentException">Sequence contained unrecognized element</exception>
        public static IDomain FromSequence(IName name, IEnumerable<IDomainDefinitionElement> sequence)
        {
            // These may appear multiple times in any order.
            var actions = new List<IAction>();
            var axioms = new List<IAxiom>();

            // Each of these must only occur once.
            IReadOnlyList<IRequirement>? requirements = null;
            IReadOnlyList<IType>? types = null;
            IReadOnlyList<IConstant>? constants = null;
            IReadOnlyList<IAtomicFormulaSkeleton>? predicates = null;
            IReadOnlyList<ILiteral<IName>>? timeless = null;
            IReadOnlyList<IName>? extensions = null;
            IReadOnlyList<IGoalDescription>? safety = null;
            IReadOnlyList<IDomainVariable>? variables = null;

            foreach (var element in sequence)
            {
                // Multiple actions are allowed.
                if (element is IDomainActionElement actionElement)
                {
                    actions.Add(actionElement.Action);
                    continue;
                }

                // Multiple axioms are allowed.
                if (element is IDomainAxiomElement axiomElement)
                {
                    axioms.Add(axiomElement.Axiom);
                    continue;
                }

                // Only one extension is allowed.
                if (element is IDomainExtensionDefinition extensionElement)
                {
                    if (!ReferenceEquals(extensions, null)) throw new ParseException(":extends definition occured more than once");
                    extensions = extensionElement.Names;
                    continue;
                }

                // Only one requirement is allowed.
                if (element is IDomainRequireDefinition requireElement)
                {
                    if (!ReferenceEquals(requirements, null)) throw new ParseException(":requirements definition occured more than once");
                    requirements = requireElement.Requirements;
                    continue;
                }

                // Only one types is allowed.
                if (element is IDomainTypesDefinition typesElement)
                {
                    if (!ReferenceEquals(types, null)) throw new ParseException(":types definition occured more than once");
                    types = typesElement.Types;
                    continue;
                }

                // Only one constants is allowed.
                if (element is IDomainConstantsDefinition constantsElement)
                {
                    if (!ReferenceEquals(constants, null)) throw new ParseException(":constants definition occured more than once");
                    constants = constantsElement.Constants;
                    continue;
                }

                // Only one vars is allowed.
                if (element is IDomainVarsDefinition varsElement)
                {
                    if (!ReferenceEquals(variables, null)) throw new ParseException(":domain-variables definition occured more than once");
                    variables = varsElement.Variables;
                    continue;
                }

                // Only one predicates is allowed.
                if (element is IDomainPredicatesDefinition predicatesElement)
                {
                    if (!ReferenceEquals(predicates, null)) throw new ParseException(":predicates definition occured more than once");
                    predicates = predicatesElement.Predicates;
                    continue;
                }

                // Only one timeless is allowed.
                if (element is IDomainTimelessDefinition timelessElement)
                {
                    if (!ReferenceEquals(timeless, null)) throw new ParseException(":timeless definition occured more than once");
                    timeless = timelessElement.Timeless;
                    continue;
                }

                // Only one vars is allowed.
                if (element is IDomainSafetyDefinition safetyElement)
                {
                    if (!ReferenceEquals(safety, null)) throw new ParseException(":safety definition occured more than once");
                    safety = safetyElement.Safety;
                    continue;
                }

                throw new ArgumentException("Sequence contained unrecognized element");
            }

            var domain = new Domain(name)
                         {
                             // These define the structure.
                             Actions = actions,
                             Axioms = axioms
                         };

            if (extensions != null) domain.Extends = extensions;
            if (requirements != null) domain.Requirements = requirements;
            if (types != null) domain.Types = types;
            if (constants != null) domain.Constants = constants;
            if (predicates != null) domain.Predicates = predicates;
            if (timeless != null) domain.Timeless = timeless;
            if (safety != null) domain.Safety = safety;
            if (variables != null) domain.Variables = variables;

            return domain;
        }
    }
}
