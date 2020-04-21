using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.ProblemParsers
{
    /// <summary>
    /// Class ProblemDefinitionParser.
    /// </summary>
    internal sealed class ProblemDefinitionParser : ParserBase<IProblem>
    {
        public ProblemDefinitionParser(ParenthesisParser parenthesis, KeywordParsers keywordParsers, NameNonTokenParser nameNonTokenParser, ProblemDefinitionElementsParser problemDefinitionElementsParser)
        {
            Parser =
                // header
                from open in parenthesis.Opening
                from problemKeyword in keywordParsers.Problem
                from problemName in nameNonTokenParser.Token()
                from close in parenthesis.Closing

                from dopen in parenthesis.Opening
                from domainKeyword in keywordParsers.CDomain
                from domainName in nameNonTokenParser.Token()
                from dclose in parenthesis.Closing

                // definition body
                from body in problemDefinitionElementsParser.Parser

                // bundle and go
                select ProblemFactory.FromSequence(problemName, domainName, body);
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IProblem> Parser { get; }
    }
}
