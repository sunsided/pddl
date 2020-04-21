using System.Collections.Generic;
using System.Linq;
using PDDL.PDDL12.Abstractions.Variables;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.TypedListParsers
{
    /// <summary>
    /// Creates the type list (IConstant).
    /// </summary>
    internal sealed class TypedListOfDomainVariableParser : ParserBase<IEnumerable<IDomainVariable>>
    {
        public TypedListOfDomainVariableParser(TypeParser typeParserGrammar, DomainVariableParser domainVariableParser)
        {
            Parser = (
                    from variables in domainVariableParser.Token().AtLeastOnce()
                    from t in Parse.Char('-').Token().Then(_ => typeParserGrammar.Parser).Token().Optional()
                    select variables.Select(var =>
                    {
                        // bind the optional type
                        if (t.IsDefined) var.Type = t.Get();
                        return var;
                    })
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IEnumerable<IDomainVariable>> Parser { get; }

    }
}
