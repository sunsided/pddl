using System.Collections.Generic;
using JetBrains.Annotations;
using PDDL.Model.PDDL12;
using Sprache;

namespace PDDL.Parser.PDDL12
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

        /// <summary>
        /// Creates the vars.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IVariableDefinition&gt;&gt;.</returns>
        [NotNull]
        private static Parser<IEnumerable<IVariableDefinition>> CreateVarsDefinition() =>
        (
            from keyword in Keywords.CVars
            from open in CommonGrammar.OpeningParenthesis
            from variables in TypedLists.TypedListOfVariable.Token()
            from close in CommonGrammar.ClosingParenthesis
            select variables
        ).Token();
    }
}
