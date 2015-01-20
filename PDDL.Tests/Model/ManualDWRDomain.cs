using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Types;

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

            IReadOnlyList<IVariable> constants = new IVariable[0];

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
            
            IReadOnlyList<ILiteral> timeless = new ILiteral[0];
            
            var domain = new Domain(name, requirements, types, constants, predicates, timeless);
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
        private static AtomicFormulaSkeleton CreatePredicate([NotNull] string name, [NotNull]  string param1, [NotNull] IType type1, [NotNull] string param2, [NotNull] IType type2)
        {
            return new AtomicFormulaSkeleton(new Predicate(name), new[]
                                                     {
                                                         new Variable(new Name(param1), type1), 
                                                         new Variable(new Name(param2), type2),
                                                     });
        }

        /// <summary>
        /// Creates the predicate.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="param1">The param1.</param>
        /// <param name="type1">The type1.</param>
        /// <returns>AtomicFormula.</returns>
        private static AtomicFormulaSkeleton CreatePredicate([NotNull] string name, [NotNull]  string param1, [NotNull] IType type1)
        {
            return new AtomicFormulaSkeleton(new Predicate(name), new[]
                                                     {
                                                         new Variable(new Name(param1), type1)
                                                     });
        }
    }
}
