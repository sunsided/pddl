using System;
using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Parsing;
using Sprache;
using Xunit;

namespace PDDL.Tests.PDDL12.Parser
{
    public class NameTests : IClassFixture<GrammarFixture>
    {
        private readonly PDDL12Grammar _grammar;

        public NameTests(GrammarFixture grammarFixture)
        {
            _grammar = grammarFixture.Grammar;
        }

        [Theory]
        [InlineData("robot-worker-domain")]
        [InlineData("robot3")]
        [InlineData("robot_")]
        [InlineData("kneel-b4__-__our__-__robot_overlords")]
        public void ValidNamesAreCorrectlyParsed(string input)
        {
            _grammar.NameDefinitionParser.Parse(input).Should().Be(input);
        }

        [Theory]
        [InlineData("-robot")]
        [InlineData("3robot")]
        [InlineData("_robot")]
        public void InvalidNamesFailParsing(string input)
        {
            Action parse = () => _grammar.NameDefinitionParser.Parse(input);
            parse.Should().Throw<ParseException>();
        }

        [Theory]
        [InlineData("robot-worker-domain")]
        [InlineData("robot3")]
        [InlineData("robot_")]
        [InlineData("a")]
        public void ValidNameNonTokensAreCorrectlyParsed(string input)
        {
            _grammar.NameNonTokenParser.Parse(input).Value.Should().Be(input);
        }

        [Theory]
        [InlineData("-robot")]
        [InlineData("3robot")]
        [InlineData("_robot")]
        public void InvalidNameNonTokensFailParsing(string input)
        {
            Action parse = () => _grammar.NameDefinitionParser.Parse(input);
            parse.Should().Throw<ParseException>();
        }
    }
}
