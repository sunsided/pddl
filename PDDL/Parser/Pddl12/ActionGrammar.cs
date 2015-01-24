using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PDDL.Model.Pddl12;
using PDDL.Model.Pddl12.Null;
using Sprache;
using Action = System.Action;

namespace PDDL.Parser.Pddl12
{
    /// <summary>
    /// Class ActionGrammar. This class cannot be inherited.
    /// </summary>
    internal sealed class ActionGrammar
    {
        /// <summary>
        /// The action definition
        /// </summary>
        [NotNull]
        public readonly Parser<IAction> ActionDefinition;

        /// <summary>
        /// Initializes static members of the <see cref="ActionGrammar"/> class.
        /// </summary>
        public ActionGrammar(CommonGrammar common)
        {
            ActionDefinition = CreateActionDefinition(common);
        }

        /// <summary>
        /// Creates the action definition.
        /// </summary>
        /// <returns>Parser&lt;Action&gt;.</returns>
        private Parser<IAction> CreateActionDefinition(CommonGrammar common)
        {
            var actionFunctor = NameNonToken.Token();

            var actionPreconditions = (
                from keyword in Parse.String(":precondition").Token()
                from precondition in GoalDescription
                select precondition
                ).Token();

            var actionParameters = (
                from keyword in Parse.String(":parameters").Token()
                from open in OpeningParenthesis
                from variables in TypedListOfVariable.Token()
                from close in ClosingParenthesis
                select variables
                ).Token();

            var effectDef = (
                from keyword in Parse.String(":effect").Token()
                from e in Effect.Token()
                select e
                ).Token();

            var actionDef = (
                from open in OpeningParenthesis
                from keyword in Parse.String(":action").Token()
                from functor in actionFunctor
                from parameters in actionParameters
                // action-def body following
                from vars in Vars.Optional()
                from precs in actionPreconditions.Optional()
                from e in effectDef.Optional()
                from close in ClosingParenthesis
                select new Action(functor, parameters.ToList(), (e.IsDefined ? e.Get() : NullEffect.Default))
                {
                    Variables = Wrap(vars)
                }
                ).Token();

            return actionDef;
        }
    }
}
