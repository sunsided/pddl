using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using PDDL.Parser.Pddl12;
using Sprache;

namespace PDDL.Tests
{
    static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            Sprache();

            /*
            var main = new Pddl12TokenizerTests();
            main.FixtureSetUp();
            main.TokenizationOfSimpleDomainDoesNotFail();
            */
        }

        private static void Sprache()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] resources = assembly.GetManifestResourceNames();
            string domainFileName = resources.FirstOrDefault(fileName => fileName.Contains("DWR-operators.pddl"));
            string domainDefinition = LoadNamedResourceString(assembly, domainFileName);

            string problemFileName = resources.FirstOrDefault(fileName => fileName.Contains("DWR-pb1.pddl"));
            string problemDefinition = LoadNamedResourceString(assembly, problemFileName);

            domainDefinition = RemoveAllComments(domainDefinition);
            var domain = DefineGrammar.DefineDefinition.Parse(domainDefinition);

            problemDefinition = RemoveAllComments(problemDefinition);
            var problem = DefineGrammar.DefineDefinition.Parse(problemDefinition);
        }

        /// <summary>
        /// Removes all comments.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        private static string RemoveAllComments(string source)
        {
            var sb = new StringBuilder();
            using (var reader = new StringReader(source))
            {
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
            }
            return sb.ToString();
        }

        /// <summary>
        /// Loads the named resource string.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="domainFileName">Name of the domain file.</param>
        public static string LoadNamedResourceString(Assembly assembly, string domainFileName)
        {
            using (Stream stream = assembly.GetManifestResourceStream(domainFileName))
            {
                Debug.Assert(stream != null, "stream != null");
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

    }
}
