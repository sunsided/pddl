using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using PDDL.Model.PDDL12;
using PDDL.Parser;
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

            var parser = new PDDL12Parser();

            var combined = domainDefinition + Environment.NewLine + problemDefinition;
            var definitions = parser.Parse(combined);

            var domain = definitions.Single(item => item is IDomain);
            var problem = definitions.Single(item => item is IProblem);
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
