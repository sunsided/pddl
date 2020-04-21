using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// Creates the literal(name).
    /// </summary>
    internal sealed class LiteralOfTermParser : ParserBase<ILiteral<ITerm>>
    {
        public LiteralOfTermParser(ParenthesisParser parenthesisParser, AtomicFormulaOfTermParser atomicFormulaOfTermParser, KeywordParsers keywordParsers)
        {
            Parser = BuildLiteralOfTerm(parenthesisParser, atomicFormulaOfTermParser, keywordParsers);
        }

        /// <summary>
        /// Gets the parser for a <see cref="ILiteral{T}"/> of <see cref="ITerm"/>.
        /// </summary>
        public override Parser<ILiteral<ITerm>> Parser { get; }

        private Parser<ILiteral<ITerm>> BuildLiteralOfTerm(ParenthesisParser parenthesisParser, AtomicFormulaOfTermParser atomicFormulaOfTermParser, KeywordParsers keywordParsers)
        {
            Parser<ILiteral<ITerm>> positiveLiteralTerm = (
                    from af in atomicFormulaOfTermParser.Parser
                    select new Literal<ITerm>(af.Name, af.Parameters, true))
                .Token();

            Parser<ILiteral<ITerm>> negativeLiteralTerm = (
                    from open in parenthesisParser.Opening
                    from keyword in keywordParsers.Not
                    from af in atomicFormulaOfTermParser.Parser
                    from close in parenthesisParser.Closing
                    select new Literal<ITerm>(af.Name, af.Parameters, false))
                .Token();

            return positiveLiteralTerm.Or(negativeLiteralTerm);
        }
    }
}
