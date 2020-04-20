using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.Types;

namespace PDDL.Tests.Model
{
    /// <summary>
    /// Class ManualDwrDomain.
    /// </summary>
    public class ManualDwrDomain
    {
        /// <summary>
        /// Constructs the domain.
        /// </summary>
        public void DomainConstruction()
        {
            IName name = new Name("dock-worker-robot");

            IReadOnlyList<IRequirement> requirements = new[]
                                                       {
                                                           new Requirement(":strips"),
                                                           new Requirement(":typing")
                                                       };

            var location = new CustomType(new Name("location"));
            var pile = new CustomType(new Name("pile"));
            var robot = new CustomType(new Name("robot"));
            var crane = new CustomType(new Name("crane"));
            var container = new CustomType(new Name("container"));
            IReadOnlyList<IType> types = new[]
                                         {
                                             location,
                                             pile,
                                             robot,
                                             crane,
                                             container
                                         };

            IReadOnlyList<IConstant> constants = new IConstant[0];

            IReadOnlyList<IAtomicFormulaSkeleton> predicates = new[]
                                                       {
                                                           CreatePredicate("adjacent", "?l1", location, "?l2", location),
                                                           CreatePredicate("attached", "?r", robot, "?l", location),
                                                           CreatePredicate("belong", "?k", crane, "?l", location),
                                                           CreatePredicate("belong", "?k", crane, "?l", location),

                                                           CreatePredicate("at", "?r", robot, "?l", location),
                                                           CreatePredicate("occupied", "?l", location),
                                                           CreatePredicate("loaded", "?r", robot, "?c", container),
                                                           CreatePredicate("unloaded", "?r", robot),

                                                           CreatePredicate("holding", "?k", crane, "?c", container),
                                                           CreatePredicate("empty", "?k", crane),

                                                           CreatePredicate("in", "?c", container, "?p", pile),
                                                           CreatePredicate("top", "?c", container, "?p", pile),
                                                           CreatePredicate("top", "?k1", container, "?k2", container),
                                                       };

            IReadOnlyList<ILiteral<IName>> timeless = new ILiteral<IName>[0];

            var domain = new Domain(name)
                         {
                             Requirements = requirements,
                             Types = types,
                             Constants = constants,
                             Predicates = predicates,
                             Timeless = timeless
                         };
        }

        /// <summary>
        /// Creates the predicate.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="param1">The param1.</param>
        /// <param name="type1">The type1.</param>
        /// <param name="param2">The param2.</param>
        /// <param name="type2">The type2.</param>
        /// <returns>AtomicFormula.</returns>
        private static AtomicFormulaSkeleton CreatePredicate(string name,  string param1, IType type1, string param2, IType type2)
        {
            return new AtomicFormulaSkeleton(new Predicate(name), new[]
                                                     {
                                                         new VariableDefinition(new Variable(new Name(param1)), type1),
                                                         new VariableDefinition(new Variable(new Name(param2)), type2),
                                                     });
        }

        /// <summary>
        /// Creates the predicate.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="param1">The param1.</param>
        /// <param name="type1">The type1.</param>
        /// <returns>AtomicFormula.</returns>
        private static AtomicFormulaSkeleton CreatePredicate(string name,  string param1, IType type1)
        {
            return new AtomicFormulaSkeleton(new Predicate(name), new[]
                                                     {
                                                         new VariableDefinition(new Variable(new Name(param1)), type1)
                                                     });
        }
    }
}
