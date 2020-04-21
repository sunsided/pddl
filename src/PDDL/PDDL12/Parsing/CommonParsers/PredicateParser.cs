using PDDL.PDDL12.Abstractions;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// The predicate.
    /// </summary>
    internal sealed class PredicateParser : ParserBase<IPredicate>
    {
        public PredicateParser(NameDefinitionParser nameDefinitionParser)
        {
            Parser = (
                    from value in nameDefinitionParser.Parser
                    select new Model.Predicate(value))
                .Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IPredicate> Parser { get; }
    }
}
