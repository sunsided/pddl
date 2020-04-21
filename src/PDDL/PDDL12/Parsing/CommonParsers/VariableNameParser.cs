using PDDL.PDDL12.Abstractions;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// The variable name token.
    /// </summary>
    internal sealed class VariableNameParser : ParserBase<IName>
    {
        public VariableNameParser(NameNonTokenParser nameNonTokenParser)
        {
            Parser = (
                from n in Parse.Char('?').Then(_ => nameNonTokenParser.Parser)
                select n
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IName> Parser { get; }

    }
}
