using FluentAssertions;
using PDDL.PDDL12;
using Sprache;
using Xunit;

namespace PDDL.Tests.PDDL12.Parser
{
    public class ParenthesisTests : IClassFixture<GrammarFixture>
    {
        private readonly PDDL12Grammar _grammar;

        public ParenthesisTests(GrammarFixture grammarFixture)
        {
            _grammar = grammarFixture.Grammar;
        }

        [Theory]
        [InlineData("(")]
        [InlineData("   ( ")]
        public void OpeningParenthesisIsParsed(string input)
        {
            _grammar.ParenthesisParser.Opening.Parse(input).Should().Be('(');
        }

        [Theory]
        [InlineData(")")]
        [InlineData("   ) ")]
        public void ClosingParenthesisIsParsed(string input)
        {
            _grammar.ParenthesisParser.Closing.Parse(input).Should().Be(')');
        }
    }
}
