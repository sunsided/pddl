using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class Pddl12DomainStructure. This class cannot be inherited.
    /// </summary>
    internal sealed class DomainFactory
    {
        /// <summary>
        /// Creates a <see cref="DomainFactory"/> instance from a mixed sequence of parsed domain structure elements.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>Pddl12DomainStructure.</returns>
        /// <exception cref="ArgumentException">Sequence contained unrecognized element</exception>
        [NotNull]
        public static DomainFactory FromSequence(IEnumerable<IDomainDefinitionElement> sequence)
        {
            var actions = new List<IAction>();
            var axioms = new List<IAxiom>();
            IReadOnlyList<IName> extensions = new IName[0];
            IReadOnlyList<IRequirement> requirements = new IRequirement[0];

            // iterate and sort
            foreach (var element in sequence)
            {
                // multiple actions are allowed
                var actionElement = element as IDomainActionElement;
                if (actionElement != null)
                {
                    actions.Add(actionElement.Action);
                    continue;
                }

                // multiple axioms are allowed
                var axiomElement = element as IDomainAxiomElement;
                if (axiomElement != null)
                {
                    axioms.Add(axiomElement.Axiom);
                    continue;
                }
                
                // only one extension is allowed
                var extensionElement = element as IDomainExtensionDefinition;
                if (extensionElement != null)
                {
                    extensions = extensionElement.Names;
                    continue;
                }

                // only one requirement is allowed
                var requireElement = element as IDomainRequireDefinition;
                if (requireElement != null)
                {
                    requirements = requireElement.Requirements;
                    continue;
                }

                // only one types is allowed
                var typesElement = element as IDomainTypesDefinition;
                if (typesElement != null)
                {
                    IReadOnlyList<IType> types = typesElement.Types;
                    continue;
                }

                // only one constants is allowed
                var constantsElement = element as IDomainConstantsDefinition;
                if (typesElement != null)
                {
                    IReadOnlyList<IConstant> constants = constantsElement.Constants;
                    continue;
                }

                // only one vars is allowed
                var varsElement = element as IDomainVarsDefinition;
                if (typesElement != null)
                {
                    throw new NotImplementedException(":vars");
                    continue;
                }

                // only one predicates is allowed
                var predicatesElement = element as IDomainPredicatesDefinition;
                if (predicatesElement != null)
                {
                    IReadOnlyList<IAtomicFormulaSkeleton> predicates = predicatesElement.Predicates;
                    continue;
                }

                // only one timeless is allowed
                var timelessElement = element as IDomainTimelessDefinition;
                if (predicatesElement != null)
                {
                    IReadOnlyList<ILiteral<IName>> timeless = timelessElement.Timeless;
                    continue;
                }

                // only one vars is allowed
                var safetyElement = element as IDomainSafetyDefinition;
                if (safetyElement != null)
                {
                    throw new NotImplementedException(":safety");
                }

                // or fail
                throw new ArgumentException("Sequence contained unrecognized element");
            }

            // there we go
            return new DomainFactory(
                actions.AsReadOnly(),
                axioms.AsReadOnly());
        }
    }
}
