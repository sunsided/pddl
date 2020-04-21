using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// The atomic formula of name.
    /// </summary>
    internal sealed class AtomicFormulaOfNameParser : ParserBase<IAtomicFormula<IName>>
    {
        public AtomicFormulaOfNameParser(ParenthesisParser parenthesisParser, PredicateParser predicateParser, NameNonTokenParser nameNonTokenParser)
        {
            Parser = (
                from open in parenthesisParser.Opening
                from p in predicateParser.Parser
                from names in nameNonTokenParser.Token().Many()
                from close in parenthesisParser.Closing
                select new AtomicFormula<IName>(p, names.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IAtomicFormula<IName>> Parser { get; }

    }
}
