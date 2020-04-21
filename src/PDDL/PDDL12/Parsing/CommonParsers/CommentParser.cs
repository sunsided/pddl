using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// Comments start with a semicolon and run until the end-of-line.
    /// </summary>
    internal sealed class CommentParser : ParserBase<string>
    {
        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<string> Parser { get; } =
            Parse.Char(';').Once()
                .Concat(Parse.AnyChar.Until(Parse.LineTerminator))
                .Text();
    }
}
