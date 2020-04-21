﻿using System.Linq;
using FluentAssertions;
using PDDL.PDDL12.Abstractions.Types;
using PDDL.PDDL12.Abstractions.Values;
using PDDL.PDDL12.Abstractions.Variables;
using PDDL.PDDL12.Model.Types;
using PDDL.PDDL12.Parsing;
using Sprache;
using Xunit;

namespace PDDL.Tests.Parser.Pddl12
{
    public class DomainVariablesTests
    {
        [Fact]
        public void CanParseIntegerValue()
        {
            var result = DomainVariableGrammar.Value.Parse("12");
            result.Should().BeAssignableTo<IDecimalValue>()
                .Subject.Value.Should().Be(12);
        }

        [Fact]
        public void CanParseFloatingValue()
        {
            var result = DomainVariableGrammar.Value.Parse("12.34");
            result.Should().BeAssignableTo<IDecimalValue>()
                .Subject.Value.Should().Be(12.34M);
        }

        [Fact]
        public void CanParseVariable()
        {
            var result = DomainVariableGrammar.Variable.Parse("something");
            result.Name.Value.Should().Be("something");
            result.Type.Should().Be(DefaultType.Default);
        }

        [Fact]
        public void CanParseVariableWithValue()
        {
            var result = DomainVariableGrammar.VariableWithValue.Parse("(value 42)");

            result.Name.Value.Should().Be("value");
            result.Type.Should().Be(DefaultType.Default);
            result.Should().BeAssignableTo<IConstantDomainVariable>()
                .Subject.Value.Should().BeAssignableTo<IDecimalValue>()
                .Subject.Value.Should().Be(42M);
        }

        [Fact]
        public void CanParseTypedList()
        {
            var results = TypedLists.TypedListOfDomainVariable.Parse("alice - person (num-legs 2) - integer");
            var list = results.ToList();
            list.Should().HaveCount(2)
                .And.ContainItemsAssignableTo<IDomainVariable>();

            var first = list.First();
            first.Name.Value.Should().Be("alice");
            first.Type.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("person");

            var second = list.Last();
            second.Name.Value.Should().Be("num-legs");
            second.Type.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("integer");
            second.Should().BeAssignableTo<IConstantDomainVariable>()
                .Subject.Value.Should().BeAssignableTo<IDecimalValue>()
                .Subject.Value.Should().Be(2M);
        }

        [Fact]
        public void CanParseDomainVariablesDefinition()
        {
            var results = DomainGrammar.VariablesDefinition.Parse("(:domain-variables alice - person (num-legs 2) - integer)");
            results.Variables.Should().HaveCount(2)
                .And.ContainItemsAssignableTo<IDomainVariable>();
        }
    }
}
