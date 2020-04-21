using Sprache;

namespace PDDL.PDDL12.Parsing
{
    internal static class ParserBaseExtensions
    {
        /// <inheritdoc cref="Sprache.ParserExtensions.Parse{T}(Parser{T},string)"/>
        public static T Parse<T>(this ParserBase<T> parserBase, string input) => parserBase.Parser.Parse(input);
    }
}
