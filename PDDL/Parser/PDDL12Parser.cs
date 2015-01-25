using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using PDDL.Model.PDDL12;
using PDDL.Parser.PDDL12;
using Sprache;

namespace PDDL.Parser
{
    /// <summary>
    /// Class PDDL12Parser. This class cannot be inherited.
    /// </summary>
    public sealed class PDDL12Parser
    {
        /// <summary>
        /// Parses the specified definition.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>IReadOnlyList&lt;IDefinition&gt;.</returns>
        /// <exception cref="PDDLSyntaxException">A syntax error or internal parser error occurred. </exception>
        [NotNull] 
        public IReadOnlyList<IDefinition> Parse([NotNull] StringReader reader)
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
                throw new PDDLSyntaxException(e.Message, e);
            }
        }

        /// <summary>
        /// Parses the specified definition.
        /// </summary>
        /// <param name="definition">The definition.</param>
        /// <returns>IReadOnlyList&lt;IDefinition&gt;.</returns>
        /// <exception cref="PDDLSyntaxException">A syntax error or internal parser error occurred. </exception>
        [NotNull]
        public IReadOnlyList<IDefinition> Parse([NotNull] string definition)
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
                throw new PDDLSyntaxException(e.Message, e);
            }
        }
        
        /// <summary>
        /// Removes all comments.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        private static string RemoveAllComments(string source)
        {
            using (var reader = new StringReader(source))
            {
                return RemoveAllComments(reader);
            }
        }

        /// <summary>
        /// Removes all comments.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>System.String.</returns>
        private static string RemoveAllComments([NotNull] StringReader reader)
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
