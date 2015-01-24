using Sprache;

namespace PDDL.Parser.PDDL12
{
    /// <summary>
    /// Class ParserInjector. This class cannot be inherited.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal sealed class ParserInjector<T>
    {
        /// <summary>
        /// Gets or sets the parser.
        /// </summary>
        /// <value>The parser.</value>
        public Parser<T> Parser { get; set; }
    }
}
