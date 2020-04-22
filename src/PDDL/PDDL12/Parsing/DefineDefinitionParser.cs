using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Parsing.CommonParsers;
using PDDL.PDDL12.Parsing.DomainParsers;
using PDDL.PDDL12.Parsing.ProblemParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class DefineGrammar.
    /// </summary>
    internal sealed class DefineDefinitionParser : ParserBase<IDefinition>
    {
        public DefineDefinitionParser(ParenthesisParser parenthesisParser, KeywordParsers keywordParsers, DomainDefinitionParser domainDefinitionParser, ProblemDefinitionParser problemDefinitionParser)
        {
            Parser = from openDefine in parenthesisParser.Opening
                from defineKeyword in keywordParsers.Define
                from definition in domainDefinitionParser.Parser.Or<IDefinition>(problemDefinitionParser)
                from closeDefine in parenthesisParser.Closing
                select definition;
        }

        /// <summary>
        /// The define definition
        /// </summary>
        public override Parser<IDefinition> Parser { get; }
    }
}
