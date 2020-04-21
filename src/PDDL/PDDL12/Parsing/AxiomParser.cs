using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class AxiomGrammar.
    /// </summary>
    internal class AxiomParser : ParserBase<IDomainAxiomElement>
    {
        /// <summary>
        /// Creates the axiom definition.
        /// </summary>
        /// <returns>Parser&lt;IAxiom&gt;.</returns>
        public AxiomParser(ParenthesisParser parenthesisParser, KeywordParsers keywordParsers, VarsParser varsParser, LiteralOfTermParser literalOfTermParser, GoalDescriptionParser goalDescriptionParser)
        {
            Parser = (
                from open in parenthesisParser.Opening
                from keyword in keywordParsers.CAxiom
                from vars in varsParser.Parser
                from context in keywordParsers.CContext.Then(_ => goalDescriptionParser.Parser)
                from implications in keywordParsers.CImplies.Then(_ => literalOfTermParser.Parser)
                from close in parenthesisParser.Closing
                // bundle and go
                let axiom = new Axiom(vars.ToList(), context, implications)
                select new AxiomDefinition(axiom)
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IDomainAxiomElement> Parser { get; }
    }
}
