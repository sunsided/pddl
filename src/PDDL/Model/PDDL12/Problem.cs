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
            Name = name ?? throw new ArgumentNullException(nameof(name), "name must not be null");
            Domain = domain ?? throw new ArgumentNullException(nameof(domain), "domain name must not be null");
            Goals = goals ?? throw new ArgumentNullException(nameof(goals), "goals must not be null");
        }

        /// <summary>
        /// Gets the name of the problem.
        /// </summary>
        /// <value>The problem.</value>
        public IName Name { get; }

        /// <summary>
        /// Gets the name of the domain the problem is defined in.
        /// </summary>
        /// <value>The domain.</value>
        public IName Domain { get; }

        /// <summary>
        /// Gets the requirements.
        /// </summary>
        /// <value>The requirements.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public IReadOnlyList<IRequirement> Requirements
        {
            get => _requirements;
            set => _requirements = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the objects.
        /// </summary>
        /// <value>The objects.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public IReadOnlyList<IObject> Objects
        {
            get => _objects;
            set => _objects = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the initial state or, should a situation be set,
        /// additional effects of the given situation.
        /// </summary>
        /// <value>The initial state.</value>
        /// <exception cref="System.ArgumentNullException">value</exception>
        public IReadOnlyList<ILiteral<IName>> Initial
        {
            get => _initial;
            set => _initial = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the goals.
        /// </summary>
        /// <value>The goals.</value>
        public IReadOnlyList<IGoalDescription> Goals { get; }
    }
}
