using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// The atomic formula of term.
    /// </summary>
    internal sealed class AtomicFormulaOfTermParser : ParserBase<IAtomicFormula<ITerm>>
    {
        public AtomicFormulaOfTermParser(ParenthesisParser parenthesisParser, PredicateParser predicateParser, TermParser termParser)
        {
            Parser = (
                from open in parenthesisParser.Opening
                from p in predicateParser.Parser
                from terms in termParser.Parser.Many()
                from close in parenthesisParser.Closing
                select new AtomicFormula<ITerm>(p, terms.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IAtomicFormula<ITerm>> Parser { get; }

    }
}
