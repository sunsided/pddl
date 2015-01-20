using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using PDDL.Tests.Tokenizer;
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

            // line ending
            Parser<string> eol = Parse.String("\r\n").Return(Environment.NewLine)
                                .Or(Parse.Char('\n').Return(Environment.NewLine));
            
            // comments start with a semicolon and run until the eol
            Parser<string> comment = 
                Parse.Char(';').Once()
                .Concat(Parse.AnyChar.Until(eol))
                .Text();

            // parentheses
            Parser<char> op = Parse.Char('(');
            Parser<char> cp = Parse.Char(')');

            // define a name
            // letter followed by any alphanumeric, hyphen or underscore
            Parser<string> name = Parse.Letter.AtLeastOnce()
                .Concat(Parse.Char('-').Or(Parse.Char('_').Or(Parse.LetterOrDigit)).Many()
                )
                .Text();
            
            //var name = Parse.Letter.AtLeastOnce()
            //    .Then(Parse.LetterOrDigit.Or(Parse.Char('-')).Or(Parse.Char(_)));
           
            string result = comment.Parse(domainDefinition);

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
