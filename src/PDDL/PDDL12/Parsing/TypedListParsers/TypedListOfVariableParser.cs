using System.Collections.Generic;
using System.Linq;
using PDDL.PDDL12.Abstractions.Variables;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.Types;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.TypedListParsers
{
    /// <summary>
    /// The variable name token.
    /// </summary>
    internal sealed class TypedListOfVariableParser : ParserBase<IEnumerable<IVariableDefinition>>
    {
        public TypedListOfVariableParser(VariableNameParser variableNameParser, TypeParser typeParserGrammar)
        {
            Parser = (
                    from vns in variableNameParser.Parser.AtLeastOnce()
                    from t in Parse.Char('-').Token().Then(_ => typeParserGrammar.Parser).Token().Optional()
                    let type = t.IsDefined ? t.Get() : DefaultType.Default
                    select vns.Select(vn => new VariableDefinition(new Model.Variable(vn), type))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(v => v));
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IEnumerable<IVariableDefinition>> Parser { get; }

    }
}
