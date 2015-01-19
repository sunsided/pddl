using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace PDDL.Tests.Tokenizer
{
    /// <summary>
    /// Class PddlTokenizerTests.
    /// </summary>
    [TestFixture]
    public class PddlTokenizerTests
    {
        /// <summary>
        /// Sets up the test fixture.
        /// </summary>
        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resources = assembly.GetManifestResourceNames();
            var domainFileName = resources.First(name => name.Contains("DWR-operators.pddl"));
            using (var stream = assembly.GetManifestResourceStream(domainFileName))
            {
                Debug.Assert(stream != null, "stream != null");
                using (var reader = new StreamReader(stream))
                {
                    var lol = reader.ReadToEnd();
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
            var resources = Assembly.GetExecutingAssembly().GetManifestResourceNames();
            var lol = Assembly.GetExecutingAssembly().GetManifestResourceStream("PDDL.Tests.Tokenizer.TestData.DWR-operators.pddl");
        }
    }
}
