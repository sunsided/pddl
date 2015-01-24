using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class Domain.
    /// </summary>
    public class Domain : IDomain
    {
        private IReadOnlyList<IRequirement> _requirements = new IRequirement[0];
        private IReadOnlyList<IType> _types = new IType[0];
        private IReadOnlyList<IConstant> _constants = new IConstant[0];
        private IReadOnlyList<IAtomicFormulaSkeleton> _predicates = new IAtomicFormulaSkeleton[0];
        private IReadOnlyList<ILiteral<IName>> _timeless = new ILiteral<IName>[0];
        private IReadOnlyList<IAction> _actions = new IAction[0];
        private IReadOnlyList<IAxiom> _axioms = new IAxiom[0];
        private IReadOnlyList<IName> _extends = new IName[0];
        private IReadOnlyList<IGoalDescription> _safety = new IGoalDescription[0];
        private IReadOnlyList<IDomainVariable> _variables = new IDomainVariable[0];

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Name { get; private set; }

        /// <summary>
        /// Gets the names of the extended domains.
        /// </summary>
        /// <value>The names.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IName> Extends
        {
            get { return _extends; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _extends = value;
            }
        }

        /// <summary>
        /// Gets safety constraints.
        /// </summary>
        /// <value>The constraints.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IGoalDescription> Safety
        {
            get { return _safety; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _safety = value;
            }
        }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IRequirement> Requirements
        {
            get { return _requirements; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _requirements = value;
            }
        }

        /// <summary>
        /// Gets the type definitions.
        /// </summary>
        /// <value>The types.</value>
        /// <remarks>Uses the <c>:typing</c> requirement.</remarks>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IType> Types
        {
            get { return _types; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _types = value;
            }
        }

        /// <summary>
        /// Gets the constants.
        /// </summary>
        /// <value>The constants.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IConstant> Constants
        {
            get { return _constants; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _constants = value;
            }
        }

        /// <summary>
        /// Gets the predicate definitions.
        /// </summary>
        /// <value>The predicates.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IAtomicFormulaSkeleton> Predicates
        {
            get { return _predicates; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _predicates = value;
            }
        }

        /// <summary>
        /// Gets the timeless literals.
        /// </summary>
        /// <value>The timeless literals.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<ILiteral<IName>> Timeless
        {
            get { return _timeless; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _timeless = value;
            }
        }

        /// <summary>
        /// Gets or sets the actions.
        /// </summary>
        /// <value>The actions.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IAction> Actions
        {
            get { return _actions; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _actions = value;
            }
        }

        /// <summary>
        /// Gets the domain variables.
        /// </summary>
        /// <value>The domain variables.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        [NotNull]
        public IReadOnlyList<IDomainVariable> Variables
        {
            get { return _variables; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _variables = value;
            }
        }

        /// <summary>
        /// Gets or sets the axioms.
        /// </summary>
        /// <value>The axioms.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IReadOnlyList<IAxiom> Axioms
        {
            get { return _axioms; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _axioms = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Domain"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">None of the arguments may be null. </exception>
        public Domain([NotNull] IName name)
        {
            if (ReferenceEquals(name, null)) throw new ArgumentNullException("name", "name must not be null");

            Name = name;
        }
    }
}
