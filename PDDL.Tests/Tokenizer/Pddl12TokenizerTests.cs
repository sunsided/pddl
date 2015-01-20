using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using NUnit.Framework;
using PDDL.Tokenizer;

namespace PDDL.Tests.Tokenizer
{
    /// <summary>
    /// Class PddlTokenizerTests.
    /// <para>
    /// Implements test for the <see cref="Pddl12Tokenizer"/> class.
    /// </para>
    /// </summary>
    [TestFixture]
    public class Pddl12TokenizerTests
    {
        /// <summary>
        /// The domain definition
        /// </summary>
        // ReSharper disable once NotNullMemberIsNotInitialized
        [NotNull] 
        private string _domainDefinition;

        /// <summary>
        /// A problem definition
        /// </summary>
        // ReSharper disable once NotNullMemberIsNotInitialized
        [NotNull]
        private string _problem1;

        /// <summary>
        /// Another problem definition
        /// </summary>
        // ReSharper disable once NotNullMemberIsNotInitialized
        [NotNull]
        private string _problem2;

        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        /// <exception cref="InvalidOperationException">Require test data could not be found.</exception>
        /// <exception cref="FileLoadException">A file that was found could not be loaded. </exception>
        /// <exception cref="FileNotFoundException">Test data file was not found. </exception>
        /// <exception cref="BadImageFormatException">Current assembly is not a valid assembly. </exception>
        /// <exception cref="NotImplementedException">Resource length is greater than <see cref="F:System.Int64.MaxValue" />.</exception>
        /// <exception cref="OutOfMemoryException">There is insufficient memory to allocate a buffer for the returned string. </exception>
        /// <exception cref="IOException">An I/O error occurs. </exception>
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();

            {
                var domainFileName = resources.FirstOrDefault(name => name.Contains("DWR-operators.pddl"));
                if (ReferenceEquals(domainFileName, null)) throw new InvalidOperationException("Require test data could not be found.");
                _domainDefinition = LoadNamedResourceString(assembly, domainFileName);
                if (String.IsNullOrWhiteSpace(_domainDefinition)) Assert.Fail("Domain definition could not be loaded");
            }

            {
                var problemFileName = resources.FirstOrDefault(name => name.Contains("DWR-pb1.pddl"));
                if (ReferenceEquals(problemFileName, null)) throw new InvalidOperationException("Require test data could not be found.");
                _problem1 = LoadNamedResourceString(assembly, problemFileName);
                if (String.IsNullOrWhiteSpace(_problem1)) Assert.Fail("Problem definition could not be loaded");
            }

            {
                var problemFileName = resources.FirstOrDefault(name => name.Contains("DWR-pb2.pddl"));
                if (ReferenceEquals(problemFileName, null)) throw new InvalidOperationException("Require test data could not be found.");
                _problem2 = LoadNamedResourceString(assembly, problemFileName);
                if (String.IsNullOrWhiteSpace(_problem2)) Assert.Fail("Problem definition could not be loaded");
            }
        }

        /// <summary>
        /// Loads the named resource string.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="domainFileName">Name of the domain file.</param>
        private static string LoadNamedResourceString(Assembly assembly, string domainFileName)
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

        /// <summary>
        /// Tests the tokenization of a simple domain and succeeds if the
        /// call does not fail.
        /// </summary>
        [Test]
        public void TokenizationOfSimpleDomainDoesNotFail()
        {
            var tokenizer = new Pddl12Tokenizer();

            var definitions = new[] {_domainDefinition, _problem1, _problem2};
            foreach (var definition in definitions)
            {
                using (var reader = new StringReader(definition))
                {
                    var tokens = tokenizer.Tokenize(reader);
                    Assert.NotNull(tokens, "tokens != null");

                    // dump the tokens
                    foreach (var token in tokens)
                    {
                        if (token is PDDL.Tokenizer.Tokens.Whitespace) continue;
                        Trace.WriteLine(token);
                    }
                    Trace.Flush();
                }
            }
        }
    }
}
