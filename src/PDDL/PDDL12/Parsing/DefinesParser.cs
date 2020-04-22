using System.Collections.Generic;
using PDDL.PDDL12.Abstractions;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class DefineGrammar.
    /// </summary>
    internal sealed class DefinesParser : ParserBase<IEnumerable<IDefinition>>
    {
        public DefinesParser(DefineDefinitionParser defineDefinitionParser)
        {
            Parser = defineDefinitionParser.Parser.AtLeastOnce();
        }

        /// <summary>
        /// The define definition
        /// </summary>
        public override Parser<IEnumerable<IDefinition>> Parser { get; }
    }
}
