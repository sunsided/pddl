using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model.Effects;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class EffectGrammar. This class cannot be inherited.
    /// </summary>
    internal sealed class EffectParser : ParserBase<IEffect>
    {
        public EffectParser(ParenthesisParser parenthesisParser, KeywordParsers keywordParsers, AtomicFormulaOfTermParser atomicFormulaOfTermParser)
        {
            Parser<IEffect> positiveEffect =
                (from af in atomicFormulaOfTermParser.Parser
                    select new RegularEffect(af)).Token();

            Parser<IEffect> negativeEffect =
            (
                from open in parenthesisParser.Opening
                from keyword in keywordParsers.Not
                from af in atomicFormulaOfTermParser.Parser
                from close in parenthesisParser.Closing
                select new NegatedEffect(af)).Token();

            Parser<IEffect> conjunctionEffect =
            (
                from open in parenthesisParser.Opening
                from keyword in keywordParsers.And
                from effects in Parser.Many() // Recursive call
                from close in parenthesisParser.Closing
                select new ConjunctionEffect(effects.ToArray())
            ).Token();

            Parser = positiveEffect.Or(negativeEffect).Or(conjunctionEffect);
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IEffect> Parser { get; }
    }
}
