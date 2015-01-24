using System.Linq;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Effects;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class EffectGrammar. This class cannot be inherited.
    /// </summary>
    internal sealed class EffectGrammar
    {
        #region Internal Helpers

        /// <summary>
        /// The effect parser injector
        /// </summary>
        [NotNull]
        private static readonly ParserInjector<IEffect> _effectParserInjector = new ParserInjector<IEffect>();

        #endregion

        /// <summary>
        /// The action definition
        /// </summary>
        [NotNull] 
        public static readonly Parser<IEffect> Effect =
            CreateEffect();

        #region Factory Functions
        
        /// <summary>
        /// Creates the effect.
        /// </summary>
        /// <returns>Parser&lt;IEffect&gt;.</returns>
        [NotNull]
        private static Parser<IEffect> CreateEffect()
        {
            Parser<IEffect> positiveEffect =
                (from af in CommonGrammar.AtomicFormulaOfTerm
                 select new PositiveEffect(af)).Token();

            Parser<IEffect> negativeEffect =
                (
                    from open in CommonGrammar.OpeningParenthesis
                    from keyword in Keywords.Not
                    from af in CommonGrammar.AtomicFormulaOfTerm
                    from close in CommonGrammar.ClosingParenthesis
                    select new NegativeEffect(af)).Token();

            Parser<IEffect> conjunctionEffect =
                (
                    from open in CommonGrammar.OpeningParenthesis
                    from keyword in Keywords.And
                    from effects in _effectParserInjector.Parser.Many()
                    from close in CommonGrammar.ClosingParenthesis
                    select new ConjunctionEffect(effects.ToArray())
                    ).Token();

            var effect = positiveEffect.Or(negativeEffect).Or(conjunctionEffect);
            _effectParserInjector.Parser = effect;
            return effect;
        }

        #endregion Factory Functions
    }
}
