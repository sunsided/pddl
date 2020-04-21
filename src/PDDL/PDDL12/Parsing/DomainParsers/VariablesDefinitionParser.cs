using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using PDDL.PDDL12.Parsing.TypedListParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class VariablesDefinitionParser.
    /// </summary>
    internal sealed class VariablesDefinitionParser : ParserBase<IDomainVarsDefinition>
    {
        public VariablesDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, TypedListOfDomainVariableParser typedListOfDomainVariableParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CDomainVariables
                from variables in typedListOfDomainVariableParser.Parser
                from close in parenthesis.Closing
                select new VarsDefinition(variables.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainVarsDefinition> Parser { get; }
    }
}
