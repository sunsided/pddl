using System.Collections.Generic;
using PDDL.PDDL12.Abstractions.Variables;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class VarsGrammar.
    /// </summary>
    internal static class VarsGrammar
    {
        /// <summary>
        /// The vars
        /// </summary>
        public static readonly Parser<IEnumerable<IVariableDefinition>> VarsDefinition
            = CreateVarsDefinition();

        /// <summary>
        /// Creates the vars.
        /// </summary>
        /// <returns>Parser&lt;IEnumerable&lt;IVariableDefinition&gt;&gt;.</returns>
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
