using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class PredicatesDefinitionParser.
    /// </summary>
    internal sealed class PredicatesDefinitionParser : ParserBase<IDomainPredicatesDefinition>
    {
        public PredicatesDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, AtomicFormulaSkeletonParser atomicFormulaSkeleton)
        {
            Parser =
            (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CPredicates
                from skeletons in atomicFormulaSkeleton.AtLeastOnce()
                from close in parenthesis.Closing
                select new PredicatesDefinition(skeletons.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainPredicatesDefinition> Parser { get; }
    }
}
