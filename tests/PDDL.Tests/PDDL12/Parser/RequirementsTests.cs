using System;
using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Parsing;
using Xunit;

namespace PDDL.Tests.PDDL12.Parser
{
    public class RequirementsTests : IClassFixture<GrammarFixture>
    {
        private readonly PDDL12Grammar _grammar;

        public RequirementsTests(GrammarFixture grammarFixture)
        {
            _grammar = grammarFixture.Grammar;
        }

        [Theory]
        [InlineData(":strips")]
        [InlineData(":typing")]
        [InlineData(":disjunctive-preconditions")]
        public void RequirementsAreParsedCorrectly(string input)
        {
            _grammar.RequirementParser.Parse(input).Value.Should().Be(input);
        }

        [Theory]
        [InlineData("(:requirements :strips)")]
        [InlineData("(:requirements :strips :typing)")]
        [InlineData("(:requirements :strips :typing :disjunctive-preconditions)")]
        public void DomainRequirementDefinitionsAreParsedCorrectly(string input)
        {
            Action parse = () => _grammar.DomainRequirementDefinitionParser.Parse(input);
            parse.Should().NotThrow();
        }

        [Theory]
        [InlineData("(:requirements :strips)")]
        [InlineData("(:requirements :strips :typing)")]
        [InlineData("(:requirements :strips :typing :disjunctive-preconditions)")]
        public void ProblemRequirementDefinitionsAreParsedCorrectly(string input)
        {
            Action parse = () => _grammar.ProblemRequirementDefinitionParser.Parse(input);
            parse.Should().NotThrow();
        }
    }
}
