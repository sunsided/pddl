using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Abstractions.Goals;
using PDDL.PDDL12.Parsing;
using Xunit;

namespace PDDL.Tests.Parser.Pddl12
{
    public class GoalTests : IClassFixture<GrammarFixture>
    {
        private readonly PDDL12Grammar _grammar;

        public GoalTests(GrammarFixture grammarFixture)
        {
            _grammar = grammarFixture.Grammar;
        }

        [Theory]
        [InlineData("(in house person)", true, "in", 2)]
        [InlineData("(not (at home person))", false, "at", 2)]
        public void LiteralGoalDescriptionIsParsed(string description, bool isPositive, string literalName, int numParameters)
        {
            var gd = _grammar.GoalDescriptionParser.Parse(description);

            gd.Should().BeAssignableTo<ILiteralGoalDescription>();
            var literal = gd.As<ILiteralGoalDescription>().Literal;

            literal.Positive.Should().Be(isPositive);
            literal.Name.Value.Should().Be(literalName);
            literal.Parameters.Should().HaveCount(numParameters);
        }

        [Fact]
        public void ConjunctionGoalDescriptionIsParsed()
        {
            var gd = _grammar.GoalDescriptionParser.Parse("(and (in house person) (not (at home person)) (on street person))");
            gd.Should().BeAssignableTo<IConjunctionGoalDescription>()
                .Subject.Goals.Should().HaveCount(3);
        }
    }
}
