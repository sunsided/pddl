using System;
using System.Linq;
using FluentAssertions;
using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Abstractions.Goals;
using PDDL.PDDL12.Abstractions.Types;
using PDDL.PDDL12.Abstractions.Variables;
using PDDL.PDDL12.Model.Types;
using PDDL.PDDL12.Parsing;
using Sprache;
using Xunit;

namespace PDDL.Tests.Parser
{
    /// <summary>
    /// Class Pddl12GrammarTests.
    /// </summary>
    public class Pddl12GrammarTests
    {
        [Fact]
        public void CommentsAreRecognized()
        {
            var result = CommonGrammar.Comment.Parse(
                @"; one two three
                this is not a comment");
            result.Should().Be("; one two three");
        }

        [Fact]
        public void NonCommentsCannotBeParsedAsAComment()
        {
            Action parse = () => CommonGrammar.Comment.Parse("not a comment");
            parse.Should().Throw<ParseException>();
        }

        [Theory]
        [InlineData("(")]
        [InlineData("   ( ")]
        public void OpeningParenthesisIsParsed(string input)
        {
            CommonGrammar.OpeningParenthesis.Parse(input).Should().Be('(');
        }

        [Theory]
        [InlineData(")")]
        [InlineData("   ) ")]
        public void ClosingParenthesisIsParsed(string input)
        {
            CommonGrammar.ClosingParenthesis.Parse(input).Should().Be(')');
        }

        [Theory]
        [InlineData("robot-worker-domain")]
        [InlineData("robot3")]
        [InlineData("robot_")]
        [InlineData("kneel-b4__-__our__-__robot_overlords")]
        public void ValidNamesAreCorrectlyParsed(string input)
        {
            CommonGrammar.NameDefinition.Parse(input).Should().Be(input);
        }

        [Theory]
        [InlineData("-robot")]
        [InlineData("3robot")]
        [InlineData("_robot")]
        public void InvalidNamesFailParsing(string input)
        {
            Action parse = () => CommonGrammar.NameDefinition.Parse(input);
            parse.Should().Throw<ParseException>();
        }

        [Theory]
        [InlineData("robot-worker-domain")]
        [InlineData("robot3")]
        [InlineData("robot_")]
        [InlineData("a")]
        public void ValidNameNonTokensAreCorrectlyParsed(string input)
        {
            CommonGrammar.NameNonToken.Parse(input).Value.Should().Be(input);
        }

        [Theory]
        [InlineData("-robot")]
        [InlineData("3robot")]
        [InlineData("_robot")]
        public void InvalidNameNonTokensFailParsing(string input)
        {
            Action parse = () => CommonGrammar.NameDefinition.Parse(input);
            parse.Should().Throw<ParseException>();
        }

        [Fact]
        public void TypeNamesAreCorrectlyParsed()
        {
            var type = CommonGrammar.Type.Parse("integer - number");

            type.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("integer");

            type.Kind.Should().Be(TypeKind.UserDefined);
            type.As<ICustomType>().Parent.Should().BeOfType<DefaultType>();
        }

        [Fact]
        public void TypeListsAreCorrectlyParsed()
        {
            // The following type definition is to be understood as follows:
            // - "float" and "integer" are both of type "number"
            // - "moon" is of type "rock"
            // - "something" is of an unspecified type, which defaults to "object"
            var type = TypedLists.TypedListOfType.Parse("float integer - number moon - rock something").ToArray();
            type.Should().HaveCount(4);

            type[0].Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("float");
            type[0].Parent.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("number");

            type[1].Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("integer");
            type[1].Parent.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("number");

            type[2].Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("moon");
            type[2].Parent.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("rock");

            type[3].Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("something");
            type[3].Parent.Should().BeOfType<DefaultType>()
                .Subject.Name.Value.Should().Be("object");
            type[3].Parent.Should().BeOfType<DefaultType>()
                .Subject.Kind.Should().Be(TypeKind.Default);
        }

        [Fact]
        public void EitherTypeIsParsed()
        {
            var type = CommonGrammar.Type.Parse("(either rocket something)");

            type.Should().BeAssignableTo<IEitherType>()
                .Subject.Types.Should().HaveCount(2);

            var either = type.As<IEitherType>().Types;

            either[0].Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("rocket");

            either[1].Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("something");

            // these are only type names, so default base type is implied
            either[0].As<ICustomType>().Parent.Should().BeOfType<DefaultType>();
            either[1].As<ICustomType>().Parent.Should().BeOfType<DefaultType>();
        }

        [Fact]
        public void FluentTypeIsParsed()
        {
            var type = CommonGrammar.Type.Parse("(fluent speaker)");

            type.Should().BeAssignableTo<IFluentType>()
                .Subject.Type.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("speaker");
        }

        [Fact]
        public void TypedListsWithEitherBaseType()
        {
            var type = TypedLists.TypedListOfType.Parse("something - (either rock paper scissor)").ToArray();
            type.Should().HaveCount(1);

            type[0].Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("something");

            type[0].Parent.Should().BeAssignableTo<IEitherType>()
                .Subject.Types.Should().HaveCount(3);
        }

        [Theory]
        [InlineData("(in house person)", true, "in", 2)]
        [InlineData("(not (at home person))", false, "at", 2)]
        public void LiteralGoalDescriptionIsParsed(string description, bool isPositive, string literalName, int numParameters)
        {
            var gd = GoalGrammar.GoalDescription.Parse(description);

            gd.Should().BeAssignableTo<ILiteralGoalDescription>();
            var literal = gd.As<ILiteralGoalDescription>().Literal;

            literal.Positive.Should().Be(isPositive);
            literal.Name.Value.Should().Be(literalName);
            literal.Parameters.Should().HaveCount(numParameters);
        }

        [Fact]
        public void ConjunctionGoalDescriptionIsParsed()
        {
            var gd = GoalGrammar.GoalDescription.Parse("(and (in house person) (not (at home person)) (on street person))");
            gd.Should().BeAssignableTo<IConjunctionGoalDescription>()
                .Subject.Goals.Should().HaveCount(3);
        }

        [Fact]
        public void AxiomIsParsed()
        {
            var axiomDefinition = AxiomGrammar.AxiomDefinition.Parse(@"
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
