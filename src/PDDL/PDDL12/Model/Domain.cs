using System;
using System.Collections.Generic;
using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Variables;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class Domain.
    /// </summary>
    internal sealed class Domain : IDomain
    {
        private IReadOnlyList<IRequirement> _requirements = new IRequirement[0];
        private IReadOnlyList<IType> _types = new IType[0];
        private IReadOnlyList<IConstant> _constants = new IConstant[0];
        private IReadOnlyList<IAtomicFormulaSkeleton> _predicates = new IAtomicFormulaSkeleton[0];
        private IReadOnlyList<ILiteral<IName>> _timeless = new ILiteral<IName>[0];
        private IEnumerable<IAction> _actions = new IAction[0];
        private IEnumerable<IAxiom> _axioms = new IAxiom[0];
        private IReadOnlyList<IName> _extends = new IName[0];
        private IReadOnlyList<IGoalDescription> _safety = new IGoalDescription[0];
        private IReadOnlyList<IDomainVariable> _variables = new IDomainVariable[0];
        private bool _closedWorld = true;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Name { get; }

        /// <summary>
        /// Gets or sets the names of the extended domains.
        /// </summary>
        /// <value>The names.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IName> Extends
        {
            get => _extends;
            set => _extends = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets safety constraints.
        /// </summary>
        /// <value>The constraints.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IGoalDescription> Safety
        {
            get => _safety;
            set => _safety = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IRequirement> Requirements
        {
            get => _requirements;
            set
            {
                _requirements = value ?? throw new ArgumentNullException(nameof(value));
                Update(_requirements);
            }
        }

        /// <summary>
        /// Gets or sets the type definitions.
        /// </summary>
        /// <value>The types.</value>
        /// <remarks>Uses the <c>:typing</c> requirement.</remarks>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IType> Types
        {
            get => _types;
            set => _types = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the constants.
        /// </summary>
        /// <value>The constants.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IConstant> Constants
        {
            get => _constants;
            set => _constants = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the predicate definitions.
        /// </summary>
        /// <value>The predicates.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IAtomicFormulaSkeleton> Predicates
        {
            get => _predicates;
            set => _predicates = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the timeless literals.
        /// </summary>
        /// <value>The timeless literals.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<ILiteral<IName>> Timeless
        {
            get => _timeless;
            set => _timeless = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IEnumerable<IAction> Actions
        {
            get => _actions;
            set => _actions = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the domain variables.
        /// </summary>
        /// <value>The domain variables.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IDomainVariable> Variables
        {
            get => _variables;
            set => _variables = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the axioms.
        /// </summary>
        /// <value>The axioms.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IEnumerable<IAxiom> Axioms
        {
            get => _axioms;
            set => _axioms = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Domain"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">None of the arguments may be null. </exception>
        public Domain(IName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "name must not be null");
        }

        /// <summary>
        /// Gets a value indicating whether this domain follows a closed-world assumption.
        /// </summary>
        /// <value><see langword="true" /> if the domain is a closed world; otherwise, <see langword="false" />.</value>
        public bool ClosedWorld => _closedWorld;

        /// <summary>
        /// Updates the domain based on the requirements.
        /// </summary>
        /// <param name="requirements">The requirements.</param>
        private void Update(IEnumerable<IRequirement> requirements)
        {
            var openWorld = requirements.Any(req => req.Value.Equals(":open-world", StringComparison.OrdinalIgnoreCase));
            _closedWorld = !openWorld;
        }
    }
}
