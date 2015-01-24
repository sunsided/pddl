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
        public static readonly Parser<IAction> ActionDefinition =
            CreateActionDefinition();

        #region Factory Functions

        /// <summary>
        /// Creates the action definition.
        /// </summary>
        /// <returns>Parser&lt;Action&gt;.</returns>
        [NotNull]
        private static Parser<IAction> CreateActionDefinition()
        {
            var actionFunctor = CommonGrammar.NameNonToken.Token();

            var actionPreconditions = (
                from keyword in Keywords.Precondition
                from precondition in GoalDescription
                select precondition
                ).Token();

            var actionParameters = (
                from keyword in Keywords.Parameters
                from open in CommonGrammar.OpeningParenthesis
                from variables in TypedLists.TypedListOfVariable.Token()
                from close in CommonGrammar.ClosingParenthesis
                select variables
                ).Token();

            var effectDef = (
                from keyword in Keywords.Effect
                from e in Effect.Token()
                select e
                ).Token();

            var actionDef = (
                from open in CommonGrammar.OpeningParenthesis
                from keyword in Keywords.Action
                from functor in actionFunctor
                from parameters in actionParameters
                // action-def body following
                from vars in Vars.Optional()
                from precs in actionPreconditions.Optional()
                from e in effectDef.Optional()
                from close in CommonGrammar.ClosingParenthesis
                select new Action(functor, parameters.ToList(), (e.IsDefined ? e.Get() : NullEffect.Default))
                {
                    Variables = Wrap(vars)
                }
                ).Token();

            return actionDef;
        }

        #endregion Factory Functions
    }
}
