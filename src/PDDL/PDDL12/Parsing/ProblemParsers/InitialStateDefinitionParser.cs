using System.Linq;
using PDDL.PDDL12.Abstractions.Problems;
using PDDL.PDDL12.Model.ProblemElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.ProblemParsers
{
    /// <summary>
    /// Class InitDefinitionParser.
    /// </summary>
    internal sealed class InitialStateDefinitionParser : ParserBase<IProblemInitialStateDefinition>
    {
        public InitialStateDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, LiteralOfNameParser literalOfNameParser)
        {
            Parser = (
                from open in parenthesis.Opening
                from keyword in keywordParsers.CInit
                from literals in literalOfNameParser.Many()
                from close in parenthesis.Closing
                select new ProblemInitialStateDefinition(literals.ToList())
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IProblemInitialStateDefinition> Parser { get; }
    }
}
