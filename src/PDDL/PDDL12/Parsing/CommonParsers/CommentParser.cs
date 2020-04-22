using System.Collections.Generic;
using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// Comments start with a semicolon and run until the end-of-line.
    /// </summary>
    internal sealed class CommentParser : ParserBase<IEnumerable<string>>
    {
        public CommentParser()
        {
            Parser = new Sprache.CommentParser(";", null, null, "\n")
                .SingleLineComment
                .XMany();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IEnumerable<string>> Parser { get; }
    }
}
