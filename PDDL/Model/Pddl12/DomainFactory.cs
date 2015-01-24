using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sprache;

namespace PDDL.Model.Pddl12
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
        /// <exception cref="System.NotImplementedException">
        /// :vars
        /// or
        /// :safety
        /// </exception>
        /// <exception cref="System.ArgumentException">Sequence contained unrecognized element</exception>
        /// <exception cref="ArgumentException">Sequence contained unrecognized element</exception>
        [NotNull]
        public static IDomain FromSequence([NotNull] IName name, [NotNull] IEnumerable<IDomainDefinitionElement> sequence)
        {
            // these may appear multiple times in any order
            var actions = new List<IAction>();
            var axioms = new List<IAxiom>();
            
            // each of these must only occur once
            IReadOnlyList<IRequirement> requirements = null;
            IReadOnlyList<IType> types = null;
            IReadOnlyList<IConstant> constants = null;
            IReadOnlyList<IAtomicFormulaSkeleton> predicates = null;
            IReadOnlyList<ILiteral<IName>> timeless = null;
            IReadOnlyList<IName> extensions = null;
            IReadOnlyList<IGoalDescription> safety = null;

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
                    if (!ReferenceEquals(extensions, null)) throw new ParseException(":extends definition occured more than once");
                    extensions = extensionElement.Names;
                    continue;
                }

                // only one requirement is allowed
                var requireElement = element as IDomainRequireDefinition;
                if (requireElement != null)
                {
                    if (!ReferenceEquals(requirements, null)) throw new ParseException(":requirements definition occured more than once");
                    requirements = requireElement.Requirements;
                    continue;
                }

                // only one types is allowed
                var typesElement = element as IDomainTypesDefinition;
                if (typesElement != null)
                {
                    if (!ReferenceEquals(types, null)) throw new ParseException(":types definition occured more than once");
                    types = typesElement.Types;
                    continue;
                }

                // only one constants is allowed
                var constantsElement = element as IDomainConstantsDefinition;
                if (constantsElement != null)
                {
                    if (!ReferenceEquals(constants, null)) throw new ParseException(":constants definition occured more than once");
                    constants = constantsElement.Constants;
                    continue;
                }

                // only one vars is allowed
                var varsElement = element as IDomainVarsDefinition;
                if (varsElement != null)
                {
                    throw new NotImplementedException(":vars");
                }

                // only one predicates is allowed
                var predicatesElement = element as IDomainPredicatesDefinition;
                if (predicatesElement != null)
                {
                    if (!ReferenceEquals(predicates, null)) throw new ParseException(":predicates definition occured more than once");
                    predicates = predicatesElement.Predicates;
                    continue;
                }

                // only one timeless is allowed
                var timelessElement = element as IDomainTimelessDefinition;
                if (timelessElement != null)
                {
                    if (!ReferenceEquals(timeless, null)) throw new ParseException(":timeless definition occured more than once");
                    timeless = timelessElement.Timeless;
                    continue;
                }

                // only one vars is allowed
                var safetyElement = element as IDomainSafetyDefinition;
                if (safetyElement != null)
                {
                    if (!ReferenceEquals(safety, null)) throw new ParseException(":safety definition occured more than once");
                    safety = safetyElement.Safety;
                    continue;
                }

                // or fail
                throw new ArgumentException("Sequence contained unrecognized element");
            }

            // bundle the domain
            var domain = new Domain(name)
                         {
                             // these define the structure
                             Actions = actions,
                             Axioms = axioms
                         };

            // these need to be checked first
            if (extensions != null) domain.Extends = extensions;
            if (requirements != null) domain.Requirements = requirements;
            if (types != null) domain.Types = types;
            if (constants != null) domain.Constants = constants;
            if (predicates != null) domain.Predicates = predicates;
            if (timeless != null) domain.Timeless = timeless;
            if (safety != null) domain.Safety = safety;

            // there we go
            return domain;
        }
    }
}
