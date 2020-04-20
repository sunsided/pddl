using System;
using System.Linq;
using FluentAssertions;
using PDDL.Model.PDDL12;
using PDDL.Model.PDDL12.Goals;
using PDDL.Model.PDDL12.Types;
using PDDL.Parser.PDDL12;
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
            var result = CommonGrammar.Comment.Parse("; one two three" + Environment.NewLine + "this is not a comment");
            result.Should().Be("; one two three");
        }

        [Fact]
        public void NonCommentsCannotBeParsedAsAComment()
        {
            System.Action parse = () => CommonGrammar.Comment.Parse("not a comment");
            parse.Should().Throw<ParseException>();
        }

        [Fact]
        public void OpeningParenthesisIsParsed()
        {
            CommonGrammar.OpeningParenthesis.Parse("(").ToString().Should().Be("(");
            CommonGrammar.OpeningParenthesis.Parse("   ( ").ToString().Should().Be("(");
        }

        [Fact]
        public void ClosingParenthesisIsParsed()
        {
            CommonGrammar.ClosingParenthesis.Parse(")").ToString().Should().Be(")");
            CommonGrammar.ClosingParenthesis.Parse("   ) ").ToString().Should().Be(")");
        }

        [Fact]
        public void NamesAreCorrectlyParsed()
        {
            CommonGrammar.NameDefinition.Parse("robot-worker-domain").Should().Be("robot-worker-domain");
            CommonGrammar.NameDefinition.Parse("robot-3").Should().Be("robot-3");
            CommonGrammar.NameDefinition.Parse("robot_").Should().Be("robot_");

            Assert.Throws<ParseException>(() => CommonGrammar.NameDefinition.Parse("-robot"));
            Assert.Throws<ParseException>(() => CommonGrammar.NameDefinition.Parse("3robot"));
            Assert.Throws<ParseException>(() => CommonGrammar.NameDefinition.Parse("_robot"));
        }

        [Fact]
        public void NameNonTokensAreCorrectlyParsed()
        {
            CommonGrammar.NameNonToken.Parse("robot-worker-domain").Value.Should().Be("robot-worker-domain");
            CommonGrammar.NameNonToken.Parse("robot-3").Value.Should().Be("robot-3");
            CommonGrammar.NameNonToken.Parse("robot_").Value.Should().Be("robot_");
            CommonGrammar.NameNonToken.Parse("a").Value.Should().Be("a");

            Assert.Throws<ParseException>(() => CommonGrammar.NameNonToken.Parse("-robot"));
            Assert.Throws<ParseException>(() => CommonGrammar.NameNonToken.Parse("3robot"));
            Assert.Throws<ParseException>(() => CommonGrammar.NameNonToken.Parse("_robot"));
        }

        [Fact]
        public void TypeNamesAreCorrectlyParsed()
        {
            var type = CommonGrammar.Type.Parse("integer - number");
            type.Should().BeAssignableTo<ICustomType>();
            ((ICustomType)type).Name.Value.Should().Be("integer");

            type.Kind.Should().Be(TypeKind.UserDefined);

            ((ICustomType)type).Parent.Should().BeOfType<DefaultType>();
        }

        [Fact]
        public void TypeListsAreCorrectlyParsed()
        {
            var type = TypedLists.TypedListOfType.Parse("float integer - number moon - rock something").ToArray();
            type.Length.Should().Be(4);

            type[0].Should().BeAssignableTo<ICustomType>();
            type[1].Should().BeAssignableTo<ICustomType>();
            type[2].Should().BeAssignableTo<ICustomType>();
            type[3].Should().BeAssignableTo<ICustomType>();

            ((ICustomType)type[0]).Name.Value.Should().Be("float");
            ((ICustomType)type[1]).Name.Value.Should().Be("integer");
            ((ICustomType)type[2]).Name.Value.Should().Be("moon");
            ((ICustomType)type[3]).Name.Value.Should().Be("something");

            type[0].Parent.Should().BeAssignableTo<ICustomType>();
            type[1].Parent.Should().BeAssignableTo<ICustomType>();
            type[2].Parent.Should().BeAssignableTo<ICustomType>();

            ((ICustomType)type[0].Parent).Name.Value.Should().Be("number");
            ((ICustomType)type[1].Parent).Name.Value.Should().Be("number");
            ((ICustomType)type[2].Parent).Name.Value.Should().Be("rock");

            type[3].Parent.Should().BeOfType<DefaultType>();
            type[3].Parent.Kind.Should().Be(TypeKind.Default);
        }

        [Fact]
        public void EitherTypeIsCorrectlyParsed()
        {
            var type = CommonGrammar.Type.Parse("(either rocket something)");

            type.Should().BeAssignableTo<IEitherType>();

            var either = ((IEitherType) type).Types;
            either.Count.Should().Be(2);

            either[0].Should().BeAssignableTo<ICustomType>();
            either[1].Should().BeAssignableTo<ICustomType>();

            ((ICustomType)either[0]).Name.Value.Should().Be("rocket");
            ((ICustomType)either[1]).Name.Value.Should().Be("something");

            // these are only type names, so default base type is implied
            ((ICustomType)either[0]).Parent.Should().BeOfType<DefaultType>();
            ((ICustomType)either[1]).Parent.Should().BeOfType<DefaultType>();
        }

        [Fact]
        public void FluentTypeIsCorrectlyParsed()
        {
            var type = CommonGrammar.Type.Parse("(fluent speaker)");

            type.Should().BeAssignableTo<IFluentType>();

            var fluent = ((IFluentType)type);

            fluent.Type.Should().BeAssignableTo<ICustomType>();
            ((ICustomType)fluent.Type).Name.Value.Should().Be("speaker");
        }

        [Fact]
        public void TypedListsWithEitherBaseType()
        {
            var type = TypedLists.TypedListOfType.Parse("something - (either rock paper scissor)").ToArray();
            type.Length.Should().Be(1);

            type[0].Should().BeAssignableTo<ICustomType>();

            ((ICustomType)type[0]).Name.Value.Should().Be("something");

            ((ICustomType)type[0]).Parent.Should().BeAssignableTo<IEitherType>();

            ((IEitherType)((ICustomType)type[0]).Parent).Types.Count.Should().Be(3);
        }

        [Fact]
        public void GoalDescription()
        {
            var gd = GoalGrammar.GoalDescription.Parse("(in house person)");
            gd.Should().BeAssignableTo<ILiteralGoalDescription>();
            ((ILiteralGoalDescription)gd).Literal.Name.Value.Should().Be("in");
            ((ILiteralGoalDescription)gd).Literal.Parameters.Count.Should().Be(2);

            gd = GoalGrammar.GoalDescription.Parse("(not (at home person))");
            gd.Should().BeAssignableTo<ILiteralGoalDescription>();
            ((ILiteralGoalDescription)gd).Literal.Positive.Should().Be(false);
            ((ILiteralGoalDescription)gd).Literal.Name.Value.Should().Be("at");
            ((ILiteralGoalDescription)gd).Literal.Parameters.Count.Should().Be(2);

            gd = GoalGrammar.GoalDescription.Parse("(and (in house person) (not (at home person)) (on street person))");
            gd.Should().BeAssignableTo<IConjunctionGoalDescription>();
            ((IConjunctionGoalDescription)gd).Goals.Count.Should().Be(3);
        }

        [Fact]
        public void Axiom()
        {
            var axd = AxiomGrammar.AxiomDefinition.Parse("(:axiom :vars (?x ?y - physob) :context (on ?x ?y) :implies (above ?x ?y))");
            var ax = axd.Axiom;

            ax.Variables.Count.Should().Be(2);
            ax.Context.Should().BeAssignableTo<ILiteralGoalDescription>();
            ((ILiteralGoalDescription)ax.Context).Literal.Name.Value.Should().Be("on");
            ax.Implication.Name.Value.Should().Be("above");
        }
    }
}
