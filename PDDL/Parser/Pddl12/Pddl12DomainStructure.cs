using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class Pddl12DomainStructure. This class cannot be inherited.
    /// </summary>
    internal sealed class Pddl12DomainStructure
    {
        /// <summary>
        /// Gets or sets the axiom.
        /// </summary>
        /// <value>The axiom.</value>
        [NotNull]
        public IReadOnlyList<IAction> Actions { get; set; }

        /// <summary>
        /// Gets or sets the axiom.
        /// </summary>
        /// <value>The axiom.</value>
        [NotNull]
        public IReadOnlyList<IAxiom> Axioms { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pddl12DomainStructure"/> class.
        /// </summary>
        /// <param name="actions">The actions.</param>
        /// <param name="axioms">The axioms.</param>
        private Pddl12DomainStructure([NotNull] IReadOnlyList<IAction> actions, [NotNull] IReadOnlyList<IAxiom> axioms)
        {
            Actions = actions;
            Axioms = axioms;
        }

        /// <summary>
        /// Creates a <see cref="Pddl12DomainStructure"/> instance from a mixed sequence of parsed domain structure elements.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>Pddl12DomainStructure.</returns>
        /// <exception cref="ArgumentException">Sequence contained unrecognized element</exception>
        [NotNull]
        public static Pddl12DomainStructure FromSequence(IEnumerable<IDomainStructureElement> sequence)
        {
            var actions = new List<IAction>();
            var axioms = new List<IAxiom>();

            // iterate and sort
            foreach (var element in sequence)
            {
                // find the appropriate list
                if (element is IAction)
                {
                    actions.Add((IAction)element);
                    continue;
                }
                if (element is IAxiom)
                {
                    axioms.Add((IAxiom)element);
                    continue;
                }
                
                // or fail
                throw new ArgumentException("Sequence contained unrecognized element");
            }

            // there we go
            return new Pddl12DomainStructure(
                actions.AsReadOnly(),
                axioms.AsReadOnly());
        }
    }
}
