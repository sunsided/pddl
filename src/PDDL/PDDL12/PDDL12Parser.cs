using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Parsing;
using Sprache;

namespace PDDL.PDDL12
{
    /// <summary>
    /// Parser for PDDL 1.2. This class cannot be inherited.
    /// </summary>
    public sealed class PDDL12Parser
    {
        /// <summary>
        /// Parses the specified definition.
        /// </summary>
        /// <param name="reader">The text reader to read from.</param>
        /// <returns>A list of definitions.</returns>
        /// <exception cref="PddlSyntaxException">A syntax error or internal parser error occurred. </exception>
        public IReadOnlyList<IDefinition> Parse(TextReader reader)
        {
            // strip all comments
            var definition = RemoveAllComments(reader);

            // run the actual parsers
            try
            {
                var enumeration = DefineGrammar.MultiDefineDefinition.Parse(definition);
                return enumeration.ToList();
            }
            catch (ParseException e)
            {
                throw new PddlSyntaxException(e.Message, e);
            }
        }

        /// <summary>
        /// Parses the specified definition.
        /// </summary>
        /// <param name="definition">The definition.</param>
        /// <returns>A list of definitions.</returns>
        /// <exception cref="PddlSyntaxException">A syntax error or internal parser error occurred. </exception>
        public IReadOnlyList<IDefinition> Parse(string definition)
        {
            // strip all comments
            definition = RemoveAllComments(definition);

            // run the actual parsers
            try
            {
                var enumeration = DefineGrammar.MultiDefineDefinition.Parse(definition);
                return enumeration.ToList();
            }
            catch (ParseException e)
            {
                throw new PddlSyntaxException(e.Message, e);
            }
        }

        /// <summary>
        /// Removes all comments.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        private static string RemoveAllComments(string source)
        {
            using var reader = new StringReader(source);
            return RemoveAllComments(reader);
        }

        /// <summary>
        /// Removes all comments.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>System.String.</returns>
        private static string RemoveAllComments(TextReader reader)
        {
            var sb = new StringBuilder();

            string line;
            while (null != (line = reader.ReadLine()))
            {
                // check for semicolons and, if none found, simply register the line
                var index = line.IndexOf(';');
                if (index < 0)
                {
                    sb.AppendLine(line);
                    continue;
                }

                // if a semicolon was found, read until there and replace it with a single whitespace
                // (as per language description)
                sb.Append(line.Substring(0, index));
                sb.AppendLine(" ");
            }

            return sb.ToString();
        }
    }
}
