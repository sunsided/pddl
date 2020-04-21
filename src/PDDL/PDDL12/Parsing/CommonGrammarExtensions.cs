using System;
using System.Collections.Generic;
using System.Linq;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class CommonGrammar. This class cannot be inherited.
    /// </summary>
    internal static class CommonGrammarExtensions
    {
        /// <summary>
        /// Wraps the specified option.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="option">The option.</param>
        /// <returns>IReadOnlyList&lt;T&gt;.</returns>
        internal static IReadOnlyList<T> AsReadOnlyList<T>(this IOption<IEnumerable<T>> option) =>
            option.IsDefined
                ? option.Get().ToList().AsReadOnly()
                : (IReadOnlyList<T>) ArraySegment<T>.Empty;

        /// <summary>
        /// Wraps the specified option.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="option">The option.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>IReadOnlyList&lt;T&gt;.</returns>
        internal static T Wrap<T>(this IOption<T> option, T defaultValue) =>
            option.IsDefined
                ? option.Get()
                : defaultValue;
    }
}
