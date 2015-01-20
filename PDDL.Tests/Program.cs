using PDDL.Tests.Tokenizer;

namespace PDDL.Tests
{
    static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            var main = new Pddl12TokenizerTests();
            main.FixtureSetUp();
            main.TokenizationOfSimpleDomainDoesNotFail();
        }
    }
}
