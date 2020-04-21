using PDDL.PDDL12.Abstractions;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// The variable.
    /// </summary>
    internal sealed class VariableParser : ParserBase<IVariable>
    {
        public VariableParser(VariableNameParser variableNameParser)
        {
            Parser = (
                from n in variableNameParser.Parser
                select new Model.Variable(n)
            ).Token();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IVariable> Parser { get; }
    }
}
