using PDDL.PDDL12.Abstractions;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// The term.
    /// </summary>
    internal sealed class TermParser : ParserBase<ITerm>
    {
        public TermParser(NameNonTokenParser nameNonTokenParser, VariableParser variableParser)
        {
            Parser = nameNonTokenParser.Token()
                .Or<ITerm>(variableParser);
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<ITerm> Parser { get; }
    }
}
