using System.Linq;
using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Abstractions.Types;
using PDDL.PDDL12.Model.Types;
using PDDL.PDDL12.Parsing;
using Xunit;

namespace PDDL.Tests.PDDL12.Parser
{
    public class TypeTests : IClassFixture<GrammarFixture>
    {
        private readonly PDDL12Grammar _grammar;

        public TypeTests(GrammarFixture grammarFixture)
        {
            _grammar = grammarFixture.Grammar;
        }

        [Fact]
        public void TypeNamesAreCorrectlyParsed()
        {
            var type = _grammar.TypeParser.Parse("integer - number");

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
            var type = _grammar.TypedListOfTypeParser.Parse("float integer - number moon - rock something").ToArray();
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
            var type = _grammar.TypeParser.Parse("(either rocket something)");

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
            var type = _grammar.TypeParser.Parse("(fluent speaker)");

            type.Should().BeAssignableTo<IFluentType>()
                .Subject.Type.Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("speaker");
        }

        [Fact]
        public void TypedListsWithEitherBaseType()
        {
            var type = _grammar.TypedListOfTypeParser.Parse("something - (either rock paper scissor)").ToArray();
            type.Should().HaveCount(1);

            type[0].Should().BeAssignableTo<ICustomType>()
                .Subject.Name.Value.Should().Be("something");

            type[0].Parent.Should().BeAssignableTo<IEitherType>()
                .Subject.Types.Should().HaveCount(3);
        }
    }
}
