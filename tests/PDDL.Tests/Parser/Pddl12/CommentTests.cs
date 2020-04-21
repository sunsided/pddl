using System;
using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Parsing;
using Sprache;
using Xunit;

namespace PDDL.Tests.Parser.Pddl12
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
            result.Should().Be("; one two three");
        }

        [Fact]
        public void NonCommentsCannotBeParsedAsAComment()
        {
            Action parse = () => _grammar.CommentParser.Parse("not a comment");
            parse.Should().Throw<ParseException>();
        }
    }
}
