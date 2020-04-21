using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// The name as non-token (i.e. for use in variable names).
    /// </summary>
    internal sealed class NameNonTokenParser : ParserBase<IName>
    {
        public NameNonTokenParser(NameDefinitionParser nameDefinitionParser)
        {
            Parser =
                from value in nameDefinitionParser.Parser
                select new Name(value);
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IName> Parser { get; }

    }
}
