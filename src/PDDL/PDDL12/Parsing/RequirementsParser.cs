using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class RequirementsGrammar.
    /// </summary>
    internal sealed class RequirementsParser : ParserBase<IRequirement>
    {
        /// <summary>
        /// The valid requirements
        /// </summary>
        public override Parser<IRequirement> Parser { get; } =
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
    }
}
