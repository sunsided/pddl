using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class Problem. This class cannot be inherited.
    /// </summary>
    internal sealed class Problem : IProblem
    {
        private IReadOnlyList<IRequirement> _requirements = new IRequirement[0];
        private IReadOnlyList<IObject> _objects = new IObject[0];
        private IReadOnlyList<ILiteral<IName>> _initial = new ILiteral<IName>[0];

        /// <summary>
        /// Gets the name of the problem.
        /// </summary>
        /// <value>The problem.</value>
        public IName Name { get; private set; }

        /// <summary>
        /// Gets the name of the domain the problem is defined in.
        /// </summary>
        /// <value>The domain.</value>
        public IName Domain { get; private set; }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
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
        /// Gets the objects.
        /// </summary>
        /// <value>The objects.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public IReadOnlyList<IObject> Objects
        {
            get { return _objects; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _objects = value;
            }
        }

        /// <summary>
        /// Gets the initial state or, should a situation be set,
        /// additional effects of the given situation.
        /// </summary>
        /// <value>The initial state.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public IReadOnlyList<ILiteral<IName>> Initial
        {
            get { return _initial; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _initial = value;
            }
        }

        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <value>The goals.</value>
        public IReadOnlyList<IGoalDescription> Goals { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Problem" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="goals">The goals.</param>
        /// <exception cref="System.ArgumentNullException">name;name must not be null
        /// or
        /// domain;domain name must not be null</exception>
        public Problem([NotNull] IName name, [NotNull] IName domain, IReadOnlyList<IGoalDescription> goals)
        {
            if (ReferenceEquals(name, null)) throw new ArgumentNullException("name", "name must not be null");
            if (ReferenceEquals(domain, null)) throw new ArgumentNullException("domain", "domain name must not be null");
            if (ReferenceEquals(goals, null)) throw new ArgumentNullException("goals", "goals must not be null");

            Name = name;
            Domain = domain;
            Goals = goals;
        }
    }
}
