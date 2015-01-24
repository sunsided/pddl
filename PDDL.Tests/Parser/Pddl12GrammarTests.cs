using System;
using System.Linq;
using JetBrains.Annotations;
using NUnit.Framework;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Types;
using PDDL.Parser;
using PDDL.Parser.Pddl12;
using Sprache;

namespace PDDL.Tests.Parser
{
    /// <summary>
    /// Class Pddl12GrammarTests.
    /// </summary>
    [TestFixture]
    public class Pddl12GrammarTests
    {
        /// <summary>
        /// The grammar
        /// </summary>
        [NotNull]
        private readonly Gammar _grammar = new Gammar();

        /// <summary>
        /// Comments are correctly parsed when at the appropriate position
        /// </summary>
        [Test]
        public void CommentsAreRecognized()
        {
            var result = CommonGrammar.Comment.Parse("; one two three" + Environment.NewLine + "this is not a comment");
            Assert.AreEqual("; one two three", result);

            Assert.Throws<ParseException>(() => CommonGrammar.Comment.Parse("not a comment"));
        }

        [Test]
        public void OpeningParenthesisIsParsed()
        {
            Assert.AreEqual("(", Gammar.OpeningParenthesis.Parse("(").ToString());
            Assert.AreEqual("(", Gammar.OpeningParenthesis.Parse("   ( ").ToString());
        }

        [Test]
        public void ClosingParenthesisIsParsed()
        {
            Assert.AreEqual(")", Gammar.ClosingParenthesis.Parse(")").ToString());
            Assert.AreEqual(")", Gammar.ClosingParenthesis.Parse("   ) ").ToString());
        }

        [Test]
        public void NamesAreCorrectlyParsed()
        {
            Assert.AreEqual("robot-worker-domain", Gammar.NameDefinition.Parse("robot-worker-domain"));
            Assert.AreEqual("robot-3", Gammar.NameDefinition.Parse("robot-3"));
            Assert.AreEqual("robot_", Gammar.NameDefinition.Parse("robot_"));

            Assert.Throws<ParseException>(() => Gammar.NameDefinition.Parse("-robot"));
            Assert.Throws<ParseException>(() => Gammar.NameDefinition.Parse("3robot"));
            Assert.Throws<ParseException>(() => Gammar.NameDefinition.Parse("_robot"));
        }

        [Test]
        public void NameNonTokensAreCorrectlyParsed()
        {
            Assert.AreEqual("robot-worker-domain", Gammar.NameNonToken.Parse("robot-worker-domain").Value);
            Assert.AreEqual("robot-3", Gammar.NameNonToken.Parse("robot-3").Value);
            Assert.AreEqual("robot_", Gammar.NameNonToken.Parse("robot_").Value);
            Assert.AreEqual("a", Gammar.NameNonToken.Parse("a").Value);

            Assert.Throws<ParseException>(() => Gammar.NameNonToken.Parse("-robot"));
            Assert.Throws<ParseException>(() => Gammar.NameNonToken.Parse("3robot"));
            Assert.Throws<ParseException>(() => Gammar.NameNonToken.Parse("_robot"));
        }

        [Test]
        public void TypeNamesAreCorrectlyParsed()
        {
            var type = _grammar.Type.Parse("integer - number");
            Assert.IsInstanceOf<ICustomType>(type);
            Assert.AreEqual("integer", ((ICustomType)type).Name);

            Assert.IsInstanceOf<DefaultType>(((ICustomType)type).Parent);
        }

        [Test]
        public void TypeListsAreCorrectlyParsed()
        {
            var type = _grammar.TypedListOfType.Parse("float integer - number moon - rock something").ToArray();
            Assert.AreEqual(4, type.Length);

            Assert.IsInstanceOf<ICustomType>(type[0]);
            Assert.IsInstanceOf<ICustomType>(type[1]);
            Assert.IsInstanceOf<ICustomType>(type[2]);
            Assert.IsInstanceOf<ICustomType>(type[3]);

            Assert.AreEqual("float", ((ICustomType)type[0]).Name);
            Assert.AreEqual("integer", ((ICustomType)type[1]).Name);
            Assert.AreEqual("moon", ((ICustomType)type[2]).Name);
            Assert.AreEqual("something", ((ICustomType)type[3]).Name);

            Assert.IsInstanceOf<ICustomType>(((ICustomType)type[0]).Parent);
            Assert.IsInstanceOf<ICustomType>(((ICustomType)type[1]).Parent);
            Assert.IsInstanceOf<ICustomType>(((ICustomType)type[2]).Parent);

            Assert.AreEqual("number", ((ICustomType)((ICustomType)type[0]).Parent).Name);
            Assert.AreEqual("number", ((ICustomType)((ICustomType)type[1]).Parent).Name);
            Assert.AreEqual("rock", ((ICustomType)((ICustomType)type[2]).Parent).Name);

            Assert.IsInstanceOf<DefaultType>(((ICustomType)type[3]).Parent);
        }

        [Test]
        public void EitherTypeIsCorrectlyParsed()
        {
            var type = _grammar.Type.Parse("(either rocket something)");

            Assert.IsInstanceOf<IEitherType>(type);

            var either = ((IEitherType) type).Types;
            Assert.AreEqual(2, either.Count);

            Assert.IsInstanceOf<ICustomType>(either[0]);
            Assert.IsInstanceOf<ICustomType>(either[1]);

            Assert.AreEqual("rocket", ((ICustomType)either[0]).Name);
            Assert.AreEqual("something", ((ICustomType)either[1]).Name);

            // these are only type names, so default base type is implied
            Assert.IsInstanceOf<DefaultType>(((ICustomType)either[0]).Parent);
            Assert.IsInstanceOf<DefaultType>(((ICustomType)either[1]).Parent);
        }

        [Test]
        public void FluentTypeIsCorrectlyParsed()
        {
            var type = _grammar.Type.Parse("(fluent speaker)");

            Assert.IsInstanceOf<IFluentType>(type);

            var fluent = ((IFluentType)type);

            Assert.IsInstanceOf<ICustomType>(fluent.Type);
            Assert.AreEqual("speaker", ((ICustomType)fluent.Type).Name);
        }

        [Test]
        public void TypedListsWithEitherBaseType()
        {
            var type = _grammar.TypedListOfType.Parse("something - (either rock paper scissor)").ToArray();
            Assert.AreEqual(1, type.Length);

            Assert.IsInstanceOf<ICustomType>(type[0]);

            Assert.AreEqual("something", ((ICustomType)type[0]).Name);

            Assert.IsInstanceOf<IEitherType>(((ICustomType)type[0]).Parent);

            Assert.AreEqual(3, ((IEitherType)((ICustomType)type[0]).Parent).Types.Count);
        }

        [Test]
        public void GoalDescription()
        {
            var gd = _grammar.GoalDescription.Parse("(in house person)");
            Assert.IsInstanceOf<ILiteralGoalDescription>(gd);
            Assert.AreEqual("in", ((ILiteralGoalDescription)gd).Literal.Name.Value);
            Assert.AreEqual(2, ((ILiteralGoalDescription)gd).Literal.Parameters.Count);

            gd = _grammar.GoalDescription.Parse("(not (at home person))");
            Assert.IsInstanceOf<ILiteralGoalDescription>(gd);
            Assert.AreEqual(false, ((ILiteralGoalDescription)gd).Literal.Positive);
            Assert.AreEqual("at", ((ILiteralGoalDescription)gd).Literal.Name.Value);
            Assert.AreEqual(2, ((ILiteralGoalDescription)gd).Literal.Parameters.Count);

            gd = _grammar.GoalDescription.Parse("(and (in house person) (not (at home person)) (on street person))");
            Assert.IsInstanceOf<IConjunctionGoalDescription>(gd);
            Assert.AreEqual(3, ((IConjunctionGoalDescription)gd).Goals.Count);
        }

        [Test]
        public void Axiom()
        {
            var ax = _grammar.AxiomDefinition.Parse("(:axiom :vars (?x ?y - physob) :context (on ?x ?y) :implies (above ?x ?y))");
            Assert.AreEqual(2, ax.Variables.Count);
            Assert.IsInstanceOf<ILiteralGoalDescription>(ax.Context);
            Assert.AreEqual("on", ((ILiteralGoalDescription)ax.Context).Literal.Name);
            Assert.AreEqual("above", ax.Implication.Name);
        }
    }
}
