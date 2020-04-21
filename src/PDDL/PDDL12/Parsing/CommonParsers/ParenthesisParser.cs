using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    internal sealed class ParenthesisParser
    {
        /// <summary>
        /// Gets the parser.
        /// </summary>
        public Parser<char> Opening { get; } = Parse.Char('(').Token();

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public Parser<char> Closing { get; } = Parse.Char(')').Token();
    }
}
