using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Sprache;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class ProblemFactory. This class cannot be inherited.
    /// </summary>
    internal sealed class ProblemFactory
    {
        /// <summary>
        /// Creates a <see cref="ProblemFactory" /> instance from a mixed sequence of parsed domain structure elements.
        /// </summary>
        [NotNull]
        public static IProblem FromSequence([NotNull] IName name, [NotNull] IName domainName, [NotNull] IEnumerable<IProblemDefinitionElement> sequence)
        {
            // there may be multiple goals
            var goals = new List<IGoalDescription>();

            // each of these must only occur once
            IReadOnlyList<IRequirement> requirements = null;
            IReadOnlyList<IObject> objects = null;
            IReadOnlyList<ILiteral<IName>> initial = null;

            // iterate and sort
            foreach (var element in sequence)
            {
                // only one requirement is allowed
                var requireElement = element as IProblemRequireDefinition;
                if (requireElement != null)
                {
                    if (!ReferenceEquals(requirements, null)) throw new ParseException(":requirements definition occured more than once");
                    requirements = requireElement.Requirements;
                    continue;
                }

                // only one types is allowed
                var objectsElement = element as IProblemObjectsDefinition;
                if (objectsElement != null)
                {
                    if (!ReferenceEquals(objects, null)) throw new ParseException(":objects definition occured more than once");
                    objects = objectsElement.Objects;
                    continue;
                }

                // only one constants is allowed
                var initialElement = element as IProblemInitialStateDefinition;
                if (initialElement != null)
                {
                    if (!ReferenceEquals(initial, null)) throw new ParseException(":constants definition occured more than once");
                    initial = initialElement.State;
                    continue;
                }

                // only one vars is allowed
                var goalElement = element as IProblemGoalDefinition;
                if (goalElement != null)
                {
                    goals.Add(goalElement.Goal);
                    continue;
                }

                // or fail
                throw new ArgumentException("Sequence contained unrecognized element");
            }

            // bundle the domain
            var problem = new Problem(name, domainName, goals);

            // these need to be checked first
            if (requirements != null) problem.Requirements = requirements;
            if (initial != null) problem.Initial = initial;
            if (objects != null) problem.Objects = objects;

            // there we go
            return problem;
        }
    }
}
