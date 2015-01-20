﻿using System;
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
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();
            var domainFileName = resources.FirstOrDefault(name => name.Contains("DWR-operators.pddl"));
            var domainDefinition = LoadNamedResourceString(assembly, domainFileName);

            Parser<string> eol = Parse.String("\r\n").Return(Environment.NewLine)
                                .Or(Parse.Char('\n').Return(Environment.NewLine));
            Parser<string> comment = (
                from semicolon in Parse.Char(';')
                from text in Parse.AnyChar.Until(eol).Text()
                select ";" + text
                )
                .Token();

            var result = comment.Parse(domainDefinition);

        }

        /// <summary>
        /// Loads the named resource string.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="domainFileName">Name of the domain file.</param>
        public static string LoadNamedResourceString(Assembly assembly, string domainFileName)
        {
            using (var stream = assembly.GetManifestResourceStream(domainFileName))
            {
                Debug.Assert(stream != null, "stream != null");
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

    }
}
