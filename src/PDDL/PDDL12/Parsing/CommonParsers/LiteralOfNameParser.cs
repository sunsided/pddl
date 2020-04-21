using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// Creates the literal(name).
    /// </summary>
    internal sealed class LiteralOfNameParser : ParserBase<ILiteral<IName>>
    {
        public LiteralOfNameParser(ParenthesisParser parenthesisParser, AtomicFormulaOfNameParser atomicFormulaOfNameParser, KeywordParsers keywordParsers)
        {
            Parser = BuildLiteralOfName(parenthesisParser, atomicFormulaOfNameParser, keywordParsers);
        }

        /// <summary>
        /// Gets the parser for a <see cref="ILiteral{T}"/> of <see cref="IName"/>.
        /// </summary>
        public override Parser<ILiteral<IName>> Parser { get; }

        private Parser<ILiteral<IName>> BuildLiteralOfName(ParenthesisParser parenthesisParser, AtomicFormulaOfNameParser atomicFormulaOfNameParser, KeywordParsers keywordParsers)
        {
            Parser<ILiteral<IName>> positiveLiteralName = (
                    from af in atomicFormulaOfNameParser.Parser
                    select new Literal<IName>(af.Name, af.Parameters, true))
                .Token();

            Parser<ILiteral<IName>> negativeLiteralName = (
                    from open in parenthesisParser.Opening
                    from keyword in keywordParsers.Not
                    from af in atomicFormulaOfNameParser.Parser
                    from close in parenthesisParser.Closing
                    select new Literal<IName>(af.Name, af.Parameters, false))
                .Token();

            return positiveLiteralName.Or(negativeLiteralName);
        }
    }
}
