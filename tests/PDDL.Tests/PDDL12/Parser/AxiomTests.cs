using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Goals;
using PDDL.PDDL12.Abstractions.Types;
using PDDL.PDDL12.Abstractions.Variables;
using PDDL.PDDL12.Parsing;
using Xunit;

namespace PDDL.Tests.PDDL12.Parser
{
    public class AxiomTests : IClassFixture<GrammarFixture>
    {
        private readonly PDDL12Grammar _grammar;

        public AxiomTests(GrammarFixture grammarFixture)
        {
            _grammar = grammarFixture.Grammar;
        }

        [Fact]
        public void AxiomIsParsed()
        {
            var axiomDefinition = _grammar.AxiomParser.Parse(@"
                (:axiom 
                    :vars (?x ?y - physob) 
                    :context (on ?x ?y) 
                    :implies (not (above ?x ?y)))");

            var axiom = axiomDefinition.Axiom;

            axiom.VariableDefinitions.Should().HaveCount(2);
            var variableDefinitions = axiom.VariableDefinitions;

            variableDefinitions[0].Should().BeAssignableTo<IVariableDefinition>()
                .Subject.Value.Name.Value.Should().Be("x");
            variableDefinitions[0].As<IVariableDefinition>()
                .Type.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("physob");

            variableDefinitions[1].Should().BeAssignableTo<IVariableDefinition>()
                .Subject.Value.Name.Value.Should().Be("y");
            variableDefinitions[1].As<IVariableDefinition>()
                .Type.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("physob");

            axiom.Context.Should().BeAssignableTo<ILiteralGoalDescription>()
                .Subject.Literal.Name.Value.Should().Be("on");
            axiom.Context.As<ILiteralGoalDescription>()
                .Literal.Parameters.Should().HaveCount(2);

            var contextParameters = axiom.Context.As<ILiteralGoalDescription>().Literal.Parameters;
            contextParameters[0].Should().BeAssignableTo<IVariable>()
                .Subject.Name.Value.Should().Be("x");
            contextParameters[1].Should().BeAssignableTo<IVariable>()
                .Subject.Name.Value.Should().Be("y");

            axiom.Implication.Positive.Should().BeFalse();
            axiom.Implication.Name.Value.Should().Be("above");
            axiom.Implication.Parameters.Should().HaveCount(2);

            var implicationParameters = axiom.Implication.Parameters;
            implicationParameters[0].Should().BeAssignableTo<IVariable>()
                .Subject.Name.Value.Should().Be("x");
            implicationParameters[1].Should().BeAssignableTo<IVariable>()
                .Subject.Name.Value.Should().Be("y");
        }
    }
}
