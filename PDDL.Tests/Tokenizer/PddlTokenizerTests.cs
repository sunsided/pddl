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
    /// </summary>
    [TestFixture]
    public class PddlTokenizerTests
    {
        /// <summary>
        /// The domain definition
        /// </summary>
        // ReSharper disable once NotNullMemberIsNotInitialized
        [NotNull] private string _domainDefinition;

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
            var domainFileName = resources.FirstOrDefault(name => name.Contains("DWR-operators.pddl"));
            if (ReferenceEquals(domainFileName, null)) throw new InvalidOperationException("Require test data could not be found.");
            using (var stream = assembly.GetManifestResourceStream(domainFileName))
            {
                Debug.Assert(stream != null, "stream != null");
                using (var reader = new StreamReader(stream))
                {
                    _domainDefinition = reader.ReadToEnd();
                }
            }

            if (String.IsNullOrWhiteSpace(_domainDefinition)) Assert.Fail("Domain definition could not be loaded");
        }

        /// <summary>
        /// Tests the tokenization of a simple domain and succeeds if the
        /// call does not fail.
        /// </summary>
        [Test]
        public void TokenizationOfSimpleDomainDoesNotFail()
        {
            var tokenizer = new PddlTokenizer();

            using (var reader = new StringReader(_domainDefinition))
            {
                var tokens = tokenizer.Tokenize(reader);
                Assert.NotNull(tokens, "tokens != null");

                var sum = tokens.Count();
                Assert.Greater(sum, 0, "at least one token expected");
            }
        }
    }
}
