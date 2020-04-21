using System.Collections.Generic;
using System.Linq;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.Types;
using PDDL.PDDL12.Parsing.CommonParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing.TypedListParsers
{
    /// <summary>
    /// Creates the type list (IConstant).
    /// </summary>
    internal sealed class TypedListOfConstantParser : ParserBase<IEnumerable<IConstant>>
    {
        public TypedListOfConstantParser(NameNonTokenParser nameNonTokenParser, TypeParser typeParserGrammar)
        {
            Parser = (
                    from names in nameNonTokenParser.Token().AtLeastOnce()
                    from t in Parse.Char('-').Token().Then(_ => typeParserGrammar.Parser).Token().Optional()
                    select names.Select(vn => new Constant(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                // ReSharper disable once PossibleMultipleEnumeration
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IEnumerable<IConstant>> Parser { get; }

    }
}
