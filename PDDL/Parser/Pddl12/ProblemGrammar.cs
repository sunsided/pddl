using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class ProblemGrammar.
    /// </summary>
    internal static class ProblemGrammar
    {


        #region Factory Functions

        /// <summary>
        /// Creates the domain definition.
        /// </summary>
        /// <returns>Parser&lt;Domain&gt;.</returns>
        [NotNull]
        private static Parser<IProblem> CreateDomainDefinition()
        {
            var definition = CreateProblemDefinitionElementParser();

            return (
                // header
                from open in CommonGrammar.OpeningParenthesis
                from domainKeyword in Keywords.Problem
                from domainName in CommonGrammar.NameNonToken.Token()
                from close in CommonGrammar.ClosingParenthesis
                // definition body
                from body in definition
                // bundle and go
                select DomainFactory.FromSequence(domainName, body)
                );
        }

        #endregion Factory Functions
    }
}
