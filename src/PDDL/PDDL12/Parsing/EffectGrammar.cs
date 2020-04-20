using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model.Effects;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class EffectGrammar. This class cannot be inherited.
    /// </summary>
    internal static class EffectGrammar
    {
        /// <summary>
        /// The effect parser injector
        /// </summary>
        private static readonly ParserInjector<IEffect> EffectParserInjector = new ParserInjector<IEffect>();

        /// <summary>
        /// The action definition
        /// </summary>
        public static readonly Parser<IEffect> Effect =
            CreateEffect();

        /// <summary>
        /// Creates the effect.
        /// </summary>
        /// <returns>Parser&lt;IEffect&gt;.</returns>
        private static Parser<IEffect> CreateEffect()
        {
            Parser<IEffect> positiveEffect =
                (from af in CommonGrammar.AtomicFormulaOfTerm
                 select new RegularEffect(af)).Token();

            Parser<IEffect> negativeEffect =
                (
                    from open in CommonGrammar.OpeningParenthesis
                    from keyword in Keywords.Not
                    from af in CommonGrammar.AtomicFormulaOfTerm
                    from close in CommonGrammar.ClosingParenthesis
                    select new NegatedEffect(af)).Token();

            Parser<IEffect> conjunctionEffect =
                (
                    from open in CommonGrammar.OpeningParenthesis
                    from keyword in Keywords.And
                    from effects in EffectParserInjector.Parser.Many()
                    from close in CommonGrammar.ClosingParenthesis
                    select new ConjunctionEffect(effects.ToArray())
                    ).Token();

            var effect = positiveEffect.Or(negativeEffect).Or(conjunctionEffect);
            EffectParserInjector.Parser = effect;
            return effect;
        }
    }
}
