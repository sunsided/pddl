using System.Collections.Generic;
using PDDL.PDDL12.Abstractions.Variables;
using PDDL.PDDL12.Parsing.CommonParsers;
using PDDL.PDDL12.Parsing.TypedListParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class VarsGrammar.
    /// </summary>
    internal class VarsParser : ParserBase<IEnumerable<IVariableDefinition>>
    {
        public VarsParser(ParenthesisParser parenthesisParser, KeywordParsers keywordParsers,
            TypedListOfVariableParser tlv)
        {
            Parser =
            (
                from keyword in keywordParsers.CVars
                from open in parenthesisParser.Opening
                from variables in tlv.Token()
                from close in parenthesisParser.Closing
                select variables
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IEnumerable<IVariableDefinition>> Parser { get; }
    }
}
