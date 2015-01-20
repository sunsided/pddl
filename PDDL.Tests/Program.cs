using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Types;
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
                .Concat(Parse.AnyChar.Until(Parse.LineTerminator))
                .Text();
            Assert.AreEqual("; aww yeah", comment.Parse("; aww yeah"));

            // parentheses
            Parser<char> op = Parse.Char('(').Token();
            Parser<char> cp = Parse.Char(')').Token();

            // define a name
            // letter followed by any alphanumeric, hyphen or underscore
            Parser<string> nameDefinition = Parse.Letter.AtLeastOnce()
                .Concat(
                    Parse.Char('-').Or(Parse.Char('_')).Or(Parse.LetterOrDigit).Many()
                )
                .Text();

            Parser<IName> name = (from value in nameDefinition
                select new Name(value));

            Assert.AreEqual("dock-worker-robot", name.Parse("dock-worker-robot").ToString());
            Assert.AreEqual("a-b_c3", name.Parse("a-b_c3"));
            Assert.AreEqual("a123", name.Parse("a123"));
            Assert.AreEqual("a---", name.Parse("a---"));
            try { name.Parse("?a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("3a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("-a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("_a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("#a"); Assert.Fail(); } catch (ParseException) { }

            // predicates are just names
            Parser<string> predicate = nameDefinition;

            // this injector is used to decouple the recursive grammar construction
            var tpi = new ParserInjector<IType>();

            // simple name type definition
            Parser<IType> typeDefinition = (
                from value in name
                select new CustomType(value)
                ).Token();

            // (either <type>+) definition
            Parser<IType> eitherTypeDefinition = (
                from open in op
                from keyword in Parse.String("either").Token()
                from types in tpi.Parser.AtLeastOnce().Token()
                from close in cp
                select new EitherType(types.ToList())
                ).Token();
            
            // (fluent <type>) definition
            Parser<IType> fluentTypeDefinition = (
                from open in op
                from keyword in Parse.String("fluent").Token()
                from t in tpi.Parser
                from close in cp
                select new FluentType(t)
                ).Token();

            // final parser for types
            Parser<IType> type = typeDefinition.Or(eitherTypeDefinition).Or(fluentTypeDefinition);
            tpi.Parser = type;

            // var lol = type.Parse("(fluent (either foo bar frobnik))");

            /*
            // variables are named by question marks followed with a regular name
            Parser<IVariable> defaultTypeVariable = (
                from qm in Parse.Char('?')
                from value in name
                select new Variable(value, DefaultType.Default)
                ).Token();

            Assert.AreEqual("?a - object", defaultTypeVariable.Parse("?a").ToString());
            try { defaultTypeVariable.Parse("a"); Assert.Fail(); }
            catch (ParseException) { }
            */

            // typed lists of variables are just many variables
            Parser<IName> variableName =
                (
                    from n in Parse.Char('?').Then(_ => name)
                    select n
                    ).Token();

            Parser<IEnumerable<IVariable>> typedListVariable = (
                from vns in variableName.AtLeastOnce()
                from t in Parse.Char('-').Token().Then(_ => type).Token().Optional()
                let variables = from vn in vns
                    select new Variable(vn, t.IsDefined ? t.Get() : DefaultType.Default)
                select variables
                )
                .Many()
                .Select(groupedPerType => groupedPerType.SelectMany(variable => variable));

            Debugger.Break();
/*

            Assert.AreEqual(3, typedListVariable.Parse("?a?b ?c").Count());
            Assert.AreEqual(1, typedListVariable.Parse("?a lol").Count());
            Assert.AreEqual(0, typedListVariable.Parse("lol ?a").Count());
              */
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
        /// Class ParserInjector. This class cannot be inherited.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        sealed class ParserInjector<T>
        {
            /// <summary>
            /// Gets or sets the parser.
            /// </summary>
            /// <value>The parser.</value>
            public Parser<T> Parser { get; set; }
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
