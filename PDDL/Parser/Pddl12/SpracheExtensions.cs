using System;
using System.Collections.Generic;
using PDDL.Model.Pddl12;
using Sprache;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class SpracheExtensions.
    /// </summary>
    internal static class SpracheExtensions
    {
        /// <summary>
        /// Gets the specified option.
        /// </summary>
        /// <typeparam name="TElement">The type of the t element.</typeparam>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="option">The option.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="defaultSelector">The default selector.</param>
        /// <returns>TOut.</returns>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public static TOut GetDefinition<TElement, TOut>(this IOption<TElement> option, Func<TElement, TOut> selector, Func<TOut> defaultSelector)
            where TElement : IDomainDefinitionElement
        {
            if (!option.IsDefined || option.IsEmpty) return defaultSelector();
            return selector(option.Get());
        }

        /// <summary>
        /// Gets the specified option.
        /// </summary>
        /// <typeparam name="TElement">The type of the t element.</typeparam>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="option">The option.</param>
        /// <param name="selector">The selector.</param>
        /// <returns>TOut.</returns>
        /// <exception cref="Exception">A delegate callback throws an exception. </exception>
        public static IReadOnlyList<TOut> GetDefinition<TElement, TOut>(this IOption<TElement> option, Func<TElement, IReadOnlyList<TOut>> selector)
            where TElement : IDomainDefinitionElement
        {
            if (!option.IsDefined || option.IsEmpty) return new TOut[0];
            return selector(option.Get());
        }
    }
}
