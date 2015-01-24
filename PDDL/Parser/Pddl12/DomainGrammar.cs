using System.Linq;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class DomainGrammar.
    /// </summary>
    internal static class DomainGrammar
    {
        /// <summary>
        /// The atomic formula skeleton
        /// </summary>
        [NotNull]
        public static readonly Parser<IAtomicFormulaSkeleton> AtomicFormulaSkeleton
            = CreateAtomicFormulaSkeleton();

        #region Factory Functions

        /// <summary>
        /// Creates the atomic formula skeleton.
        /// </summary>
        /// <returns>Parser&lt;AtomicFormulaSkeleton&gt;.</returns>
        [NotNull]
        private static Parser<IAtomicFormulaSkeleton> CreateAtomicFormulaSkeleton()
        {
            return (
                from open in CommonGrammar.OpeningParenthesis
                from p in CommonGrammar.Predicate
                from variables in TypedLists.TypedListOfVariable.Token()
                from close in CommonGrammar.ClosingParenthesis
                select new AtomicFormulaSkeleton(p, variables.ToList()))
                .Token();
        }

        #endregion
    }
}
