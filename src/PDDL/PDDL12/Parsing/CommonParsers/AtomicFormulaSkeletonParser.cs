using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Parsing.TypedListParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// The atomic formula skeleton.
    /// </summary>
    internal sealed class AtomicFormulaSkeletonParser : ParserBase<IAtomicFormulaSkeleton>
    {
        public AtomicFormulaSkeletonParser(ParenthesisParser parenthesisParser, PredicateParser predicateParser, TypedListOfVariableParser typedListOfVariableParser)
        {
            Parser = (
                    from open in parenthesisParser.Opening
                    from p in predicateParser.Parser
                    from variables in typedListOfVariableParser.Token()
                    from close in parenthesisParser.Closing
                    select new Model.AtomicFormulaSkeleton(p, variables.ToList()))
                .Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IAtomicFormulaSkeleton> Parser { get; }

    }
}
