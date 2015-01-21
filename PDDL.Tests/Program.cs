﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using NUnit.Framework;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Effects;
using PDDL.Model.Pddl12.Goals;
using PDDL.Model.Pddl12.Types;
using Sprache;
using Action = PDDL.Model.Pddl12.Action;

namespace PDDL.Tests
{
    static class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            Sprache();

            /*
            var main = new Pddl12TokenizerTests();
            main.FixtureSetUp();
            main.TokenizationOfSimpleDomainDoesNotFail();
            */
        }

        private static void Sprache()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string[] resources = assembly.GetManifestResourceNames();
            string domainFileName = resources.FirstOrDefault(fileName => fileName.Contains("DWR-operators.pddl"));
            string domainDefinition = LoadNamedResourceString(assembly, domainFileName);

            // line ending
            Parser<string> eol = Parse.String("\r\n").Return(Environment.NewLine)
                                .Or(Parse.Char('\n').Return(Environment.NewLine));
            
            // comments start with a semicolon and run until the eol
            Parser<string> comment = 
                Parse.Char(';').Once()
                .Concat(Parse.AnyChar.Until(Parse.LineTerminator))
                .Text();
            Assert.AreEqual("; aww yeah", comment.Parse("; aww yeah"));

            // parentheses
            Parser<char> op = Parse.Char('(').Token();
            Parser<char> cp = Parse.Char(')').Token();

            // define a name
            // letter followed by any alphanumeric, hyphen or underscore
            Parser<string> nameDefinition = Parse.Letter.AtLeastOnce()
                .Concat(
                    Parse.Char('-').Or(Parse.Char('_')).Or(Parse.LetterOrDigit).Many()
                )
                .Text();

            Parser<IName> name = (from value in nameDefinition
                select new Name(value));

            Assert.AreEqual("dock-worker-robot", name.Parse("dock-worker-robot").ToString());
            Assert.AreEqual("a-b_c3", name.Parse("a-b_c3"));
            Assert.AreEqual("a123", name.Parse("a123"));
            Assert.AreEqual("a---", name.Parse("a---"));
            try { name.Parse("?a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("3a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("-a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("_a"); Assert.Fail(); } catch (ParseException) { }
            try { name.Parse("#a"); Assert.Fail(); } catch (ParseException) { }
            
            // this injector is used to decouple the recursive grammar construction
            var tpi = new ParserInjector<IType>();

            // simple name type definition
            Parser<IType> typeDefinition = (
                from value in name
                select new CustomType(value)
                ).Token();

            // (either <type>+) definition
            Parser<IType> eitherTypeDefinition = (
                from open in op
                from keyword in Parse.String("either").Token()
                from types in tpi.Parser.AtLeastOnce().Token()
                from close in cp
                select new EitherType(types.ToList())
                ).Token();
            
            // (fluent <type>) definition
            Parser<IType> fluentTypeDefinition = (
                from open in op
                from keyword in Parse.String("fluent").Token()
                from t in tpi.Parser
                from close in cp
                select new FluentType(t)
                ).Token();

            // final parser for types
            Parser<IType> type = typeDefinition.Or(eitherTypeDefinition).Or(fluentTypeDefinition);
            tpi.Parser = type;
            
            // var lol = type.Parse("(fluent (either foo bar frobnik))");
            
            // typed lists of variables are just many variables
            Parser<IName> variableName =
                (
                    from n in Parse.Char('?').Then(_ => name)
                    select n
                    ).Token();

            Parser<IVariable> variable = (
                from n in variableName
                select new Variable(n));

            Parser<IEnumerable<IVariable>> typedListVariable = (
                from vns in variableName.AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => type).Token().Optional()
                select vns.Select(vn => new Variable(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                .Select(groupedPerType => groupedPerType.SelectMany(v => v));

            // var lol = typedListVariable.Parse("?a ?b - foo ?c - bar ?other");
            // Debugger.Break();


            Assert.AreEqual(3, typedListVariable.Parse("?a?b ?c").Count());
            Assert.AreEqual(1, typedListVariable.Parse("?a lol").Count());
            Assert.AreEqual(0, typedListVariable.Parse("lol ?a").Count());


            // predicates are just names
            Parser<IPredicate> predicate = (
                from value in nameDefinition
                select new Predicate(value))
                .Token();

            Parser<IAtomicFormulaSkeleton> atomicFormulaSkeleton = (
                from open in op
                from p in predicate
                from variables in typedListVariable.Token()
                from close in cp
                select new AtomicFormulaSkeleton(p, variables.ToList()))
                .Token();

            Parser<IEnumerable<IAtomicFormulaSkeleton>> predicatesDef = (
                from open in op
                from keyword in Parse.String(":predicates").Token()
                from skeletons in atomicFormulaSkeleton.AtLeastOnce()
                from close in cp
                select skeletons
                ).Token();
            Assert.AreEqual(2, predicatesDef.Parse("(:predicates (foo ?a ?b) (bar))").Count());

            var extensionDef = (
                from open in op
                from keyword in Parse.String(":extends").Token()
                from names in name.Token().AtLeastOnce()
                from close in cp
                select names
                ).Token();
            Assert.AreEqual(4, extensionDef.Parse("(:extends a b c d)").Count());

            var validRequirements = 
                (from value in
                Parse.String(":strips")
                .Or(Parse.String(":typing"))
                .Or(Parse.String(":disjunctive-preconditions"))
                .Or(Parse.String(":equality"))
                .Or(Parse.String(":existential-preconditions"))
                .Or(Parse.String(":universal-preconditions"))
                .Or(Parse.String(":quantified-preconditions"))
                .Or(Parse.String(":conditional-effects"))
                .Or(Parse.String(":action-expansions"))
                .Or(Parse.String(":foreach-expansions"))
                .Or(Parse.String(":dag-expansions"))
                .Or(Parse.String(":domain-axioms"))

                .Or(Parse.String(":subgoal-through-axioms"))
                .Or(Parse.String(":safety-constraints"))
                .Or(Parse.String(":expression-evaluation"))
                .Or(Parse.String(":fluents"))
                .Or(Parse.String(":open-world"))
                .Or(Parse.String(":true-negation"))
                .Or(Parse.String(":adl"))
                .Or(Parse.String(":ucpop"))
                .Text()
                select new Requirement(value)
                ).Token();

            Parser<IEnumerable<IRequirement>> requirementsDef = (
                from open in op
                from keyword in Parse.String(":requirements").Token()
                from keys in validRequirements.Many()
                from close in cp
                select keys
                ).Token();
            Assert.AreEqual(3, requirementsDef.Parse("(:requirements :strips :equality :typing)").Count());

            var typedListType = (
                from names in name.Token().AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => type).Token().Optional()
                select names.Select(vn => new CustomType(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
            Assert.AreEqual(3, typedListType.Parse("integer float - number physob").Count());

            Parser<IEnumerable<IType>> typesDef = (
                from open in op
                from keyword in Parse.String(":types").Token()
                from types in typedListType
                from close in cp
                select types
                ).Token();
            Assert.AreEqual(3, typesDef.Parse("(:types integer float - number physob)").Count());

            var typedListConstant = (
                from names in name.Token().AtLeastOnce() // TODO This grammar always allows :typing requirement - change grammar if this is not explicitly required
                from t in Parse.Char('-').Token().Then(_ => type).Token().Optional()
                select names.Select(vn => new Constant(vn, t.IsDefined ? t.Get() : DefaultType.Default))
                )
                .Many()
                .Select(groupedPerType => groupedPerType.SelectMany(t => t));
            Assert.AreEqual(3, typedListConstant.Parse("boat house - wood mountain").Count());

            Parser<IEnumerable<IConstant>> constantsDef = (
               from open in op
               from keyword in Parse.String(":constants").Token()
               from types in typedListConstant
               from close in cp
               select types
               ).Token();
            Assert.AreEqual(4, constantsDef.Parse("(:constants boat house - metal mountain sky - mother-nature)").Count());

            // TODO: implement domain-vars-def 

            Parser<ITerm> term = name.Token().Or<ITerm>(variable);

            #region literal(term)

            Parser<IAtomicFormula> atomicFormulaTerm = (
                from open in op
               from p in predicate
               from terms in term.Many()
               from close in cp
               select new AtomicFormula(p, terms.ToList())
               ).Token();

            Parser<ILiteral> positiveLiteralTerm = (
                from af in atomicFormulaTerm
                select new Literal(af.Name, af.Parameters, true))
                .Token();

            Parser<ILiteral> negativeLiteralTerm = (
                from open in op
                from keyword in Parse.String("not").Token()
                from af in atomicFormulaTerm
                from close in cp
                select new Literal(af.Name, af.Parameters, false))
                .Token();

            Parser<ILiteral> literalTerm = positiveLiteralTerm.Or(negativeLiteralTerm);

            #endregion

            #region literal(name)

            Parser<IAtomicFormula> atomicFormulaName = (
                from open in op
                from p in predicate
                from terms in name.Token().Many()
                from close in cp
                select new AtomicFormula(p, terms.ToList())
               ).Token();

            Parser<ILiteral> positiveLiteralName = (
                from af in atomicFormulaName
                select new Literal(af.Name, af.Parameters, true))
                .Token();

            Parser<ILiteral> negativeLiteralName = (
                from open in op
                from keyword in Parse.String("not").Token()
                from af in atomicFormulaName
                from close in cp
                select new Literal(af.Name, af.Parameters, false))
                .Token();

            Parser<ILiteral> literalName = positiveLiteralName.Or(negativeLiteralName);

            #endregion

            Parser<IGoalDescription> atomicGoalDescription =
                (from af in atomicFormulaTerm
                    select new AtomicGoalDescription(af));

            Parser<IGoalDescription> literalGoalDesccription =
                (from l in literalTerm
                 select new LiteralGoalDescription(l));

            var gdi = new ParserInjector<IGoalDescription>();

            Parser<IGoalDescription> conjunctionGoalDescription =
                (
                    from open in op
                    from keyword in Parse.String("and").Token()
                    from goals in gdi.Parser.Many()
                    from close in cp
                    select new ConjunctionGoalDescription(goals.ToArray())
                    ).Token();

            var goalDescription = literalGoalDesccription.Or(atomicGoalDescription).Or(conjunctionGoalDescription);
            gdi.Parser = goalDescription;

            // TODO add :disjunctive-preconditions goals
            // TODO add :existential-preconditions goals
            // TODO add :universal-preconditions goals

            var timelessDef = (
               from open in op
               from keyword in Parse.String(":timeless").Token()
               from literals in literalName.Many()
               from close in cp
               select literals
               ).Token();
            Assert.AreEqual(3, timelessDef.Parse("(:timeless (on earth) (under sky) (not (beneath ocean)))").Count());

            // TODO: add :domain-axioms
            // TODO: add :action-expansions

            var actionFunctor = name.Token();

            var actionPreconditions = (
                from keyword in Parse.String(":precondition").Token()
                from precondition in goalDescription
                select precondition
                ).Token();

            var actionParameters = (
                from keyword in Parse.String(":parameters").Token()
                from open in op
                from variables in typedListVariable.Token()
                from close in cp
                select variables
                ).Token();
            Assert.AreEqual(3, actionParameters.Parse(":parameters (?r - robot ?from ?to - location)").Count());


            Parser<IEffect> positiveEffect =
               (from af in atomicFormulaTerm
                select new PositiveEffect(af)).Token();

            Parser<IEffect> negativeEffect =
                 (
                 from open in op
                 from keyword in Parse.String("not").Token()
                 from af in atomicFormulaTerm
                 from close in cp
                  select new NegativeEffect(af)).Token();

            var edi = new ParserInjector<IEffect>();

            Parser<IEffect> conjunctionEffect =
                (
                    from open in op
                    from keyword in Parse.String("and").Token()
                    from effects in edi.Parser.Many()
                    from close in cp
                    select new ConjunctionEffect(effects.ToArray())
                    ).Token();

            var effect = positiveEffect.Or(negativeEffect).Or(conjunctionEffect);
            edi.Parser = effect;

            Parser<IEffect> effectDef = (
                from keyword in Parse.String(":effect").Token()
                from e in effect.Token()
                select e
                ).Token();

            var actionDef = (
                from open in op
                from keyword in Parse.String(":action").Token()
                from functor in actionFunctor
                from parameters in actionParameters
                // action-def body following
                from precs in actionPreconditions
                from e in effectDef
                from close in cp
                select new Action(functor, parameters.ToList(), e)
                ).Token();

            Parser<IDomain> domainDef =
                (
                    from open in op
                    from domainKeyword in Parse.String("domain").Token()
                    from domainName in name.Token()
                    from close in cp
                    from extensions in extensionDef.Optional()
                    from requirements in requirementsDef.Optional()
                    from types in typesDef.Optional()
                    from constants in constantsDef.Optional()
                    from predicates in predicatesDef.Optional()
                    from timeless in timelessDef.Optional()
                    // structure-def following
                    from actions in actionDef.Many()

                    // bundle and go
                    let ex = Wrap(extensions) 
                    let dr = Wrap(requirements)
                    let ty = Wrap(types)
                    let co = Wrap(constants)
                    let pr = Wrap(predicates)
                    let tl = Wrap(timeless)
                    select new Domain(domainName, dr, ty, co, pr, tl)
                    );

            var defineDef =
                (
                    from openDefine in op
                    from defineKeyword in Parse.String("define").Token()
                    from domain in domainDef
                    from closeDefine in cp
                    select domain
                    );

            domainDefinition = RemoveAllComments(domainDefinition);
            var result = defineDef.Parse(domainDefinition);
        }

        /// <summary>
        /// Removes all comments.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>System.String.</returns>
        private static string RemoveAllComments(string source)
        {
            var sb = new StringBuilder();
            using (var reader = new StringReader(source))
            {
                string line;
                while (null != (line = reader.ReadLine()))
                {
                    // check for semicolons and, if none found, simply register the line
                    var index = line.IndexOf(';');
                    if (index < 0)
                    {
                        sb.AppendLine(line);
                        continue;
                    }

                    // if a semicolon was found, read until there and replace it with a single whitespace
                    // (as per language description)
                    sb.Append(line.Substring(0, index));
                    sb.AppendLine(" ");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Wraps the specified option.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="option">The option.</param>
        /// <returns>IReadOnlyList&lt;T&gt;.</returns>
        static IReadOnlyList<T> Wrap<T>(IOption<IEnumerable<T>> option)
        {
            return option.IsDefined ? option.Get().ToList().AsReadOnly() : (IReadOnlyList<T>) new T[0];
        }

        /// <summary>
        /// Class ParserInjector. This class cannot be inherited.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        sealed class ParserInjector<T>
        {
            /// <summary>
            /// Gets or sets the parser.
            /// </summary>
            /// <value>The parser.</value>
            public Parser<T> Parser { get; set; }
        }

        /// <summary>
        /// Loads the named resource string.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="domainFileName">Name of the domain file.</param>
        public static string LoadNamedResourceString(Assembly assembly, string domainFileName)
        {
            using (Stream stream = assembly.GetManifestResourceStream(domainFileName))
            {
                Debug.Assert(stream != null, "stream != null");
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

    }
}
