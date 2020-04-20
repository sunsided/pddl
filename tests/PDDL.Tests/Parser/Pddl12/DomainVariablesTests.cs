using System.Linq;
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
            result.Should().BeAssignableTo<IDecimalValue>();
            result.As<IDecimalValue>().Value.Should().Be(12);
        }

        [Fact]
        public void CanParseFloatingValue()
        {
            var result = DomainVariableGrammar.Value.Parse("12.34");
            result.Should().BeAssignableTo<IDecimalValue>();
            result.As<IDecimalValue>().Value.Should().Be(12.34M);
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
            result.Should().BeAssignableTo<IConstantDomainVariable>();
            result.Name.Value.Should().Be("value");
            result.Type.Should().Be(DefaultType.Default);

            result.As<IConstantDomainVariable>().Value.Should().BeAssignableTo<IDecimalValue>();
            result.As<IConstantDomainVariable>().Value.As<IDecimalValue>().Value.Should().Be(42M);
        }

        [Fact]
        public void CanParseTypedList()
        {
            var results = TypedLists.TypedListOfDomainVariable.Parse("alice - person (numlegs 2) - integer");
            var list = results.ToList();
            list.Count.Should().Be(2);
            list.Should().ContainItemsAssignableTo<IDomainVariable>();

            var first = list[0];
            first.Name.Value.Should().Be("alice");
            first.Type.Should().BeAssignableTo<ICustomType>();
            first.Type.As<ICustomType>().Name.Value.Should().Be("person");

            var second = list[1];
            second.Name.Value.Should().Be("numlegs");
            second.Type.Should().BeAssignableTo<ICustomType>();
            second.Type.As<ICustomType>().Name.Value.Should().Be("integer");
            second.Should().BeAssignableTo<IConstantDomainVariable>();
            second.As<IConstantDomainVariable>().Value.Should().BeAssignableTo<IDecimalValue>();
            second.As<IConstantDomainVariable>().Value.As<IDecimalValue>().Value.Should().Be(2M);
        }

        [Fact]
        public void CanParseDomainVariablesDefinition()
        {
            var results = DomainGrammar.VariablesDefinition.Parse("(:domain-variables alice - person (numlegs 2) - integer)");
            results.Variables.Count.Should().Be(2);
            results.Variables.Should().ContainItemsAssignableTo<IDomainVariable>();
        }
    }
}
