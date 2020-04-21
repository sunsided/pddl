using System.Collections.Generic;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Base class for parsers.
    /// </summary>
    internal abstract class ParserBase<T>
    {
        /// <summary>
        /// Gets the parser.
        /// </summary>
        public abstract Parser<T> Parser { get; }

        /// <summary>
        /// Implicitly converts an instance of <see cref="ParserBase{T}"/> to an instance of <see cref="Parser{T}"/>.
        /// </summary>
        /// <param name="parser">The parser base to convert.</param>
        /// <returns>The parser.</returns>
        public static implicit operator Parser<T>(ParserBase<T> parser) => parser.Parser;

        /// <inheritdoc cref="Sprache.Parse.Token{T}(Parser{T})"/>
        public Parser<T> Token() => Parser.Token();

        /// <inheritdoc cref="Sprache.Parse.Optional{T}(Parser{T})"/>
        public Parser<IOption<T>> Optional() => Parser.Optional();

        /// <inheritdoc cref="Sprache.Parse.AtLeastOnce{T}(Parser{T})"/>
        public Parser<IEnumerable<T>> AtLeastOnce() => Parser.AtLeastOnce();

        /// <inheritdoc cref="Sprache.Parse.Many{T}(Parser{T})"/>
        public Parser<IEnumerable<T>> Many() => Parser.Many();
    }
}
