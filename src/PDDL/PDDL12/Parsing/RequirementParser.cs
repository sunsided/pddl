using PDDL.PDDL12.Abstractions;
using PDDL.PDDL12.Model.Requirements;
using Sprache;

namespace PDDL.PDDL12.Parsing
{
    /// <summary>
    /// Class RequirementsGrammar.
    /// </summary>
    internal sealed class RequirementParser : ParserBase<IRequirement>
    {
        /// <summary>
        /// The valid requirements
        /// </summary>
        public override Parser<IRequirement> Parser { get; } =
            from value in
                Strips
                    .Or(Typing)
                    .Or(DisjunctivePreconditions)
                    .Or(Equality)
                    .Or(ExistentialPreconditions)
                    .Or(UniversalPreconditions)
                    .Or(QuantifiedPreconditions)
                    .Or(ConditionalEffects)
                    .Or(ActionExpansions)
                    .Or(ForeachExpansions)
                    .Or(DagExpansions)
                    .Or(DomainAxioms)
                    .Or(SubgoalThroughAxioms)
                    .Or(SafetyConstraints)
                    .Or(ExpressionEvaluation)
                    .Or(Fluents)
                    .Or(OpenWorld)
                    .Or(TrueNegation)
                    .Or(Adl)
                    .Or(Ucpop)
            select value;

        private static Parser<IRequirement> Strips { get; } = Requirement<StripsRequirement>(":strips");
        private static Parser<IRequirement> Typing { get; } = Requirement<TypingRequirement>(":typing");
        private static Parser<IRequirement> Equality { get; } = Requirement<EqualityRequirement>(":equality");
        private static Parser<IRequirement> DisjunctivePreconditions { get; } = Requirement<DisjunctivePreconditionsRequirement>(":disjunctive-preconditions");
        private static Parser<IRequirement> ExistentialPreconditions { get; } = Requirement<ExistentialPreconditionsRequirement>(":existential-preconditions");
        private static Parser<IRequirement> UniversalPreconditions { get; } = Requirement<UniversalPreconditionsRequirement>(":universal-preconditions");
        private static Parser<IRequirement> QuantifiedPreconditions { get; } = Requirement<QuantifiedPreconditionsRequirement>(":quantified-preconditions");
        private static Parser<IRequirement> ConditionalEffects { get; } = Requirement<ConditionalEffectsRequirement>(":conditional-effects");
        private static Parser<IRequirement> ActionExpansions { get; } = Requirement<ActionExpansionsRequirement>(":action-expansions");
        private static Parser<IRequirement> ForeachExpansions { get; } = Requirement<ForeachExpansionsRequirement>(":foreach-expansions");
        private static Parser<IRequirement> DagExpansions { get; } = Requirement<DagExpansionsRequirement>(":dag-expansions");
        private static Parser<IRequirement> DomainAxioms { get; } = Requirement<DomainAxiomsRequirement>(":domain-axioms");
        private static Parser<IRequirement> SubgoalThroughAxioms { get; } = Requirement<SubgoalThroughAxiomsRequirement>(":subgoal-through-axioms");
        private static Parser<IRequirement> SafetyConstraints { get; } = Requirement<SafetyConstraintsRequirement>(":safety-constraints");
        private static Parser<IRequirement> ExpressionEvaluation { get; } = Requirement<ExpressionEvaluationRequirement>(":expression-evaluation");
        private static Parser<IRequirement> Fluents { get; } = Requirement<FluentsRequirement>(":fluents");
        private static Parser<IRequirement> OpenWorld { get; } = Requirement<OpenWorldRequirement>(":open-world");
        private static Parser<IRequirement> TrueNegation { get; } = Requirement<TrueNegationRequirement>(":true-negation");
        private static Parser<IRequirement> Adl { get; } = Requirement<AdlRequirement>(":adl");
        private static Parser<IRequirement> Ucpop { get; } = Requirement<AdlRequirement>(":ucpop");

        private static Parser<IRequirement> Requirement<T>(string value)
            where T : IRequirement, new()
        {
            return Parse.String(value).Token().Named(value).Text().Select(x => (IRequirement) new T());
        }
    }
}
