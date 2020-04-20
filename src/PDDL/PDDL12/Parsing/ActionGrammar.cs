using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using PDDL.PDDL12.Model;
using PDDL.PDDL12.Model.DomainElements;
using PDDL.PDDL12.Model.Null;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class ActionGrammar. This class cannot be inherited.
    /// </summary>
    internal static class ActionGrammar
    {
        /// <summary>
        /// The action definition
        /// </summary>
        public static readonly Parser<IDomainActionElement> ActionDefinition = CreateActionDefinition();

        /// <summary>
        /// Creates the action definition.
        /// </summary>
        /// <returns>Parser&lt;Action&gt;.</returns>
        private static Parser<IDomainActionElement> CreateActionDefinition()
        {
            var actionFunctor = CommonGrammar.NameNonToken.Token();

            var actionPreconditions = (
                from keyword in Keywords.CPrecondition
                from precondition in GoalGrammar.GoalDescription
                select precondition
                ).Token();

            var actionParameters = (
                from keyword in Keywords.CParameters
                from open in CommonGrammar.OpeningParenthesis
                from variables in TypedLists.TypedListOfVariable.Token()
                from close in CommonGrammar.ClosingParenthesis
                select variables
                ).Token();

            var effectDef = (
                from keyword in Keywords.CEffect
                from e in EffectGrammar.Effect.Token()
                select e
                ).Token();

            var actionDef = (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.CAction
                from functor in actionFunctor
                from parameters in actionParameters
                // action-def body following
                from vars in VarsGrammar.VarsDefinition.Optional()
                from precs in actionPreconditions.Optional()
                from e in effectDef.Optional()
                from close in CommonGrammar.ClosingParenthesis
                // bundle and go
                let action = new Action(functor, parameters.ToList(), (e.IsDefined ? e.Get() : NullEffect.Default))
                {
                    Variables = CommonGrammar.Wrap(vars)
                }
                select new ActionDefinition(action)
                ).Token();

            return actionDef;
        }
    }
}
