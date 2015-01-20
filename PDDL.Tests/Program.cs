using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
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
            Parser<char> op = Parse.Char('(').Token();
            Parser<char> cp = Parse.Char(')').Token();

            // define a name
            // letter followed by any alphanumeric, hyphen or underscore
            Parser<string> name = Parse.Letter.AtLeastOnce()
                .Concat(
                    Parse.Char('-').Or(Parse.Char('_')).Or(Parse.LetterOrDigit).Many()
                )
                .Text()
                .Token();
            Assert.AreEqual("dock-worker-robot", name.Parse("dock-worker-robot"));
            Assert.AreEqual("a-b_c3", name.Parse("a-b_c3"));
            Assert.AreEqual("a123", name.Parse("a123"));
            Assert.AreEqual("a---", name.Parse("a---"));
            try { name.Parse("?a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("3a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("-a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("_a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("#a"); Assert.Fail(); } catch (ParseException) { }

            // predicates are just names
            Parser<string> predicate = name;

            // variables are named by question marks followed with a regular name
            Parser<string> variable = Parse.Char('?').Once().Concat(name).Text().Token();
            Assert.AreEqual("?a", variable.Parse("?a"));
            try { variable.Parse("a"); Assert.Fail(); } catch (ParseException) {}
            
            // types are just names
            var type = name;
            var eitherType = (
                from open in op
                from keyword in Parse.String("either").Token()
                from types in type.AtLeastOnce().Token()
                from close in cp
                select types.ToList()
                ).Token();
            var fluentType = (
                from open in op
                from keyword in Parse.String("fluent").Token()
                from t in type
                from close in cp
                select t
                ).Token();

            // typed lists of variables are just many variables
            Parser<IEnumerable<string>> typedListVariable = variable.Many().Token();
            Assert.AreEqual(3, typedListVariable.Parse("?a?b ?c").Count());
            Assert.AreEqual(1, typedListVariable.Parse("?a lol").Count());
            Assert.AreEqual(0, typedListVariable.Parse("lol ?a").Count());

            /*
            var typedListVariable = Parse.Char('?').Once().Concat(name);

            var atomicFormulaSkeleton = (
                from open in op
                from wp1 in Parse.WhiteSpace.Many()
                from p in predicate
                from wp2 in Parse.WhiteSpace.AtLeastOnce()
                from variables in typedListVariable
                from close in cp
                select p)
                .Token();
            /*
            Parser<IList<string>> predicateDef = (
                from open in op
                from colon in Parse.Char(':')
                from whitespace in Parse.WhiteSpace.Many()
                from skeleton in atomicFormulaSkeleton
                from close in cp
                select skeleton
                ).Token();
           */
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
