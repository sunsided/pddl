using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Model.Null;
using PDDL.PDDL12.Parsing.CommonParsers;
using PDDL.PDDL12.Parsing.TypedListParsers;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class ActionGrammar. This class cannot be inherited.
    /// </summary>
    internal sealed class ActionDefinitionParser : ParserBase<IDomainActionElement>
    {
        public ActionDefinitionParser(NameNonTokenParser nameNonTokenParser, KeywordParsers keywords, ParenthesisParser parenthesis, TypedListOfVariableParser typedListOfVariableParser, VarsParser varsParser, GoalDescriptionParser goalDescriptionParser, EffectParser effectParser)
        {
            var actionFunctor = nameNonTokenParser.Token();

            var actionPreconditions = (
                from keyword in keywords.CPrecondition
                from precondition in goalDescriptionParser.Parser
                select precondition
            ).Token();

            var actionParameters = (
                from keyword in keywords.CParameters
                from open in parenthesis.Opening
                from variables in typedListOfVariableParser.Token()
                from close in parenthesis.Closing
                select variables
            ).Token();

            var effectDef = (
                from keyword in keywords.CEffect
                from e in effectParser.Token()
                select e
            ).Token();

            Parser = (
                from open in parenthesis.Opening
                from keyword in keywords.CAction
                from functor in actionFunctor
                from parameters in actionParameters
                // action-def body following
                from vars in varsParser.Optional()
                from precs in actionPreconditions.Optional()
                from e in effectDef.Optional()
                from close in parenthesis.Closing
                // bundle and go
                let action = new Action(functor, parameters.ToList(), (e.IsDefined ? e.Get() : NullEffect.Default))
                {
                    Variables = vars.AsReadOnlyList()
                }
                select new ActionDefinition(action)
            ).Token();
        }

        /// <summary>
        /// The action definition
        /// </summary>
        public override Parser<IDomainActionElement> Parser { get; }
    }
}
