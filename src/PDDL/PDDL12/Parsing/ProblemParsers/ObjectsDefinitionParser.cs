using System.Linq;
using PDDL.PDDL12.Abstractions.Problems;
using PDDL.PDDL12.Model.ProblemElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using PDDL.PDDL12.Parsing.TypedListParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.ProblemParsers
{
    /// <summary>
    /// Class ObjectsDefinitionParser.
    /// </summary>
    internal sealed class ObjectsDefinitionParser : ParserBase<IProblemObjectsDefinition>
    {
        public ObjectsDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, TypedListOfObjectParser typedListOfObjectParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CObjects
                from objects in typedListOfObjectParser.Parser
                from close in parenthesis.Closing
                select new ProblemObjectsDefinition(objects.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IProblemObjectsDefinition> Parser { get; }
    }
}
