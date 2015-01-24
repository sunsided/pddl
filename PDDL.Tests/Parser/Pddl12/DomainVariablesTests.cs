using FluentAssertions;
using NUnit.Framework;
using PDDL.Model.Pddl12;
using PDDL.Parser.Pddl12;
using Sprache;

namespace PDDL.Tests.Parser.Pddl12
{
    [TestFixture]
    public class DomainVariablesTests
    {
        [Test]
        public void CanParseIntegerValue()
        {
            var result = DomainVariableGrammar.Value.Parse("12");
            result.Should().BeAssignableTo<IDecimalValue>();
            result.As<IDecimalValue>().Value.Should().Be(12);
        }

        [Test]
        public void CanParseFloatingValue()
        {
            var result = DomainVariableGrammar.Value.Parse("12.34");
            result.Should().BeAssignableTo<IDecimalValue>();
            result.As<IDecimalValue>().Value.Should().Be(12.34M);
        }
    }
}
