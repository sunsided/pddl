using System;
using FluentAssertions;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.Types;
using Xunit;

namespace PDDL.Tests.PDDL12.Model
{
    /// <summary>
    /// Class ManualDwrDomain.
    /// </summary>
    public class ManualDwrDomain
    {
        [Fact]
        public void DomainCanBeCreated()
        {
            var name = new Name("dock-worker-robot");

            var requirements = new[]
            {
                new Requirement(":strips"),
                new Requirement(":typing")
            };

            var location = new CustomType("location");
            var pile = new CustomType("pile");
            var robot = new CustomType("robot");
            var crane = new CustomType("crane");
            var container = new CustomType("container");
            var types = new[]
            {
                location,
                pile,
                robot,
                crane,
                container
            };

            var constants = new IConstant[0];

            var predicates = new[]
            {
                Predicate("adjacent", "?l1", location, "?l2", location),
                Predicate("attached", "?r", robot, "?l", location),
                Predicate("belong", "?k", crane, "?l", location),
                Predicate("belong", "?k", crane, "?l", location),

                Predicate("at", "?r", robot, "?l", location),
                Predicate("occupied", "?l", location),
                Predicate("loaded", "?r", robot, "?c", container),
                Predicate("unloaded", "?r", robot),

                Predicate("holding", "?k", crane, "?c", container),
                Predicate("empty", "?k", crane),

                Predicate("in", "?c", container, "?p", pile),
                Predicate("top", "?c", container, "?p", pile),
                Predicate("top", "?k1", container, "?k2", container),
            };

            var timeless = new ILiteral<IName>[0];

            Func<Domain> create = () => new Domain(name)
            {
                Requirements = requirements,
                Types = types,
                Constants = constants,
                Predicates = predicates,
                Timeless = timeless
            };

            create.Should().NotThrow();
        }

        /// <summary>
        /// Creates a predicate with one parameter.
        /// </summary>
        /// <param name="name">The name of the predicate.</param>
        /// <param name="param">The name of the parameter.</param>
        /// <param name="type">The type of the parameter.</param>
        /// <returns>The atomic formula skeleton.</returns>
        private static AtomicFormulaSkeleton Predicate(string name, string param, IType type) =>
            new AtomicFormulaSkeleton(new Predicate(name), new[]
            {
                new VariableDefinition(new Variable(new Name(param.TrimStart('?'))), type)
            });

        /// <summary>
        /// Creates the predicate with two parameters
        /// </summary>
        /// <param name="name">The name of the predicate.</param>
        /// <param name="param1">The name of the first parameter.</param>
        /// <param name="type1">The type of the first parameter.</param>
        /// <param name="param2">The name of the second parameter.</param>
        /// <param name="type2">The type of the second parameter.</param>
        /// <returns>The atomic formula skeleton.</returns>
        private static AtomicFormulaSkeleton Predicate(string name, string param1, IType type1, string param2, IType type2) =>
            new AtomicFormulaSkeleton(new Predicate(name), new[]
            {
                new VariableDefinition(new Variable(new Name(param1.TrimStart('?'))), type1),
                new VariableDefinition(new Variable(new Name(param2.TrimStart('?'))), type2),
            });
    }
}
