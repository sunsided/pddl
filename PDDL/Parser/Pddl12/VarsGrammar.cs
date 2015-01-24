using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class VarsGrammar.
    /// </summary>
    internal static class VarsGrammar
    {
        /// <summary>
        /// The vars
        /// </summary>
        [NotNull] 
        public static readonly Parser<IEnumerable<IVariableDefinition>> VarsDefinition
            = CreateVarsDefinition();

        #region Factory Functions

        /// <summary>
        /// Creates the vars.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IVariableDefinition&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IVariableDefinition>> CreateVarsDefinition()
        {
            return (
                from keyword in Keywords.Vars
                from open in CommonGrammar.OpeningParenthesis
                from variables in TypedLists.TypedListOfVariable.Token()
                from close in CommonGrammar.ClosingParenthesis
                select variables
                ).Token();
        }

        #endregion Factory Functions
    }
}
