using Sprache;

namespace PDDL.PDDL12.Parsing.CommonParsers
{
    /// <summary>
    /// A name is defined by a letter followed by any alphanumeric, hyphen or underscore.
    /// </summary>
    internal sealed class NameDefinitionParser : ParserBase<string>
    {
        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<string> Parser { get; } =
            Parse.Letter.AtLeastOnce()
                .Concat(Parse.Char('-')
                    .Or(Parse.Char('_'))
                    .Or(Parse.LetterOrDigit).Many())
                .Text();
    }
}
