using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Parsing;
using Xunit;

namespace PDDL.Tests.PDDL12.Parser
{
    public class CommentTests : IClassFixture<GrammarFixture>
    {
        private readonly PDDL12Grammar _grammar;

        public CommentTests(GrammarFixture grammarFixture)
        {
            _grammar = grammarFixture.Grammar;
        }

        [Fact]
        public void CommentsAreRecognized()
        {
            var result = _grammar.CommentParser.Parse(
                @"; one two three
                this is not a comment");
            result.Should().Contain(" one two three")
                .And.HaveCount(1);
        }

        [Fact]
        public void NonCommentsCannotBeParsedAsAComment()
        {
            var result = _grammar.CommentParser.Parse("not a comment");
            result.Should().HaveCount(0);
        }
    }
}
