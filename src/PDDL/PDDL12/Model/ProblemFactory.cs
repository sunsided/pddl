using System;
using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Goals;
using PDDL.PDDL12.Abstractions.Problems;
using Sprache;

namespace PDDL.PDDL12.Model
{
    /// <summary>
    /// Class ProblemFactory. This class cannot be inherited.
    /// </summary>
    internal sealed class ProblemFactory
    {
        /// <summary>
        /// Creates a <see cref="ProblemFactory" /> instance from a mixed sequence of parsed domain structure elements.
        /// </summary>
        public static IProblem FromSequence(IName name, IName domainName, IEnumerable<IProblemDefinitionElement> sequence)
        {
            // There may be multiple goals.
            var goals = new List<IGoalDescription>();

            // Each of these must only occur once.
            IReadOnlyList<IRequirement>? requirements = null;
            IReadOnlyList<IObject>? objects = null;
            IReadOnlyList<ILiteral<IName>>? initial = null;

            foreach (var element in sequence)
            {
                // Only one requirement is allowed.
                if (element is IProblemRequireDefinition requireElement)
                {
                    if (!ReferenceEquals(requirements, null)) throw new ParseException(":requirements definition occured more than once");
                    requirements = requireElement.Requirements;
                    continue;
                }

                // Only one types is allowed.
                if (element is IProblemObjectsDefinition objectsElement)
                {
                    if (!ReferenceEquals(objects, null)) throw new ParseException(":objects definition occured more than once");
                    objects = objectsElement.Objects;
                    continue;
                }

                // Only one constants is allowed.
                if (element is IProblemInitialStateDefinition initialElement)
                {
                    if (!ReferenceEquals(initial, null)) throw new ParseException(":constants definition occured more than once");
                    initial = initialElement.State;
                    continue;
                }

                // Only one vars is allowed.
                if (element is IProblemGoalDefinition goalElement)
                {
                    goals.Add(goalElement.Goal);
                    continue;
                }

                throw new ArgumentException("Sequence contained unrecognized element");
            }

            var problem = new Problem(name, domainName, goals);

            if (requirements != null) problem.Requirements = requirements;
            if (initial != null) problem.Initial = initial;
            if (objects != null) problem.Objects = objects;

            return problem;
        }
    }
}
