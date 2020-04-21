using PDDL.PDDL12.Parsing;
using PDDL.PDDL12.Parsing.CommonParsers;
using PDDL.PDDL12.Parsing.DomainParsers;
using PDDL.PDDL12.Parsing.ProblemParsers;
using PDDL.PDDL12.Parsing.TypedListParsers;
using RequirementsDefinitionParser = PDDL.PDDL12.Parsing.DomainParsers.RequirementsDefinitionParser;

namespace PDDL.PDDL12
{
    /// <summary>
    /// Grammar for PDDL 1.2
    /// </summary>
    internal sealed class PDDL12Grammar
    {
        public PDDL12Grammar()
        {
            CommentParser = new CommentParser();
            ParenthesisParser = new ParenthesisParser();
            KeywordParsers = new KeywordParsers();
            NameDefinitionParser = new NameDefinitionParser();
            PredicateParser = new PredicateParser(NameDefinitionParser);

            NameNonTokenParser = new NameNonTokenParser(NameDefinitionParser);

            VariableNameParser = new VariableNameParser(NameNonTokenParser);
            VariableParser = new VariableParser(VariableNameParser);
            TermParser = new TermParser(NameNonTokenParser, VariableParser);

            DomainVariableParser = new DomainVariableParser(NameNonTokenParser, ParenthesisParser);

            TypeParser = new TypeParser(ParenthesisParser, NameNonTokenParser);
            TypedListOfTypeParser = new TypedListOfTypeParser(NameNonTokenParser, TypeParser);
            TypedListOfConstantParser = new TypedListOfConstantParser(NameNonTokenParser, TypeParser);
            TypedListOfVariableParser = new TypedListOfVariableParser(VariableNameParser, TypeParser);
            TypedListOfObjectParser = new TypedListOfObjectParser(NameNonTokenParser, TypeParser);
            TypedListOfDomainVariableParser = new TypedListOfDomainVariableParser(TypeParser, DomainVariableParser);

            AtomicFormulaSkeletonParser = new AtomicFormulaSkeletonParser(ParenthesisParser, PredicateParser, TypedListOfVariableParser);
            AtomicFormulaOfNameParser = new AtomicFormulaOfNameParser(ParenthesisParser, PredicateParser, NameNonTokenParser);
            AtomicFormulaOfTermParser = new AtomicFormulaOfTermParser(ParenthesisParser, PredicateParser, TermParser);

            LiteralOfNameParser = new LiteralOfNameParser(ParenthesisParser, AtomicFormulaOfNameParser, KeywordParsers);
            LiteralOfTermParser = new LiteralOfTermParser(ParenthesisParser, AtomicFormulaOfTermParser, KeywordParsers);

            GoalDescriptionParser = new GoalDescriptionParser(ParenthesisParser, KeywordParsers, AtomicFormulaOfTermParser, LiteralOfTermParser);

            VarsParser = new VarsParser(ParenthesisParser, KeywordParsers, TypedListOfVariableParser);
            EffectParser = new EffectParser(ParenthesisParser, KeywordParsers, AtomicFormulaOfTermParser);

            RequirementsParser = new RequirementsParser();
            ExtensionDefinitionParser = new ExtensionDefinitionParser(ParenthesisParser, KeywordParsers, NameNonTokenParser);
            DomainRequirementDefinitionParser = new RequirementsDefinitionParser(ParenthesisParser, KeywordParsers, RequirementsParser);
            TypesDefinitionParser = new TypesDefinitionParser(ParenthesisParser, KeywordParsers, TypedListOfTypeParser);
            ConstantsDefinitionParser = new ConstantsDefinitionParser(ParenthesisParser, KeywordParsers, TypedListOfConstantParser);
            VariablesDefinitionParser = new VariablesDefinitionParser(ParenthesisParser, KeywordParsers, TypedListOfDomainVariableParser);
            PredicatesDefinitionParser = new PredicatesDefinitionParser(ParenthesisParser, KeywordParsers, AtomicFormulaSkeletonParser);
            TimelessDefinitionParser = new TimelessDefinitionParser(ParenthesisParser, KeywordParsers, LiteralOfNameParser);
            SafetyDefinitionParser = new SafetyDefinitionParser(ParenthesisParser, KeywordParsers, GoalDescriptionParser);
            ActionDefinitionParser = new ActionDefinitionParser(NameNonTokenParser, KeywordParsers, ParenthesisParser, TypedListOfVariableParser, VarsParser, GoalDescriptionParser, EffectParser);
            AxiomParser = new AxiomParser(ParenthesisParser, KeywordParsers, VarsParser, LiteralOfTermParser, GoalDescriptionParser);
            DomainDefinitionElementsParser = new DomainDefinitionElementsParser(ExtensionDefinitionParser, DomainRequirementDefinitionParser, TypesDefinitionParser, ConstantsDefinitionParser, VariablesDefinitionParser, PredicatesDefinitionParser, TimelessDefinitionParser, SafetyDefinitionParser, ActionDefinitionParser, AxiomParser);
            DomainDefinitionParser = new DomainDefinitionParser(ParenthesisParser, KeywordParsers, NameNonTokenParser, DomainDefinitionElementsParser);

            ProblemRequirementDefinitionParser = new Parsing.ProblemParsers.RequirementsDefinitionParser(ParenthesisParser, KeywordParsers, RequirementsParser);
            InitialStateDefinitionParser = new InitialStateDefinitionParser(ParenthesisParser, KeywordParsers, LiteralOfNameParser);
            ObjectsDefinitionParser = new ObjectsDefinitionParser(ParenthesisParser, KeywordParsers, TypedListOfObjectParser);
            GoalDefinitionParser = new GoalDefinitionParser(ParenthesisParser, KeywordParsers, GoalDescriptionParser);
            ProblemDefinitionElementsParser = new ProblemDefinitionElementsParser(ProblemRequirementDefinitionParser, InitialStateDefinitionParser, ObjectsDefinitionParser, GoalDefinitionParser);
            ProblemDefinitionParser = new ProblemDefinitionParser(ParenthesisParser, KeywordParsers, NameNonTokenParser, ProblemDefinitionElementsParser);

            DefineDefinitionParser = new DefineDefinitionParser(ParenthesisParser, KeywordParsers, DomainDefinitionParser, ProblemDefinitionParser);
        }

        public CommentParser CommentParser { get; }
        public ParenthesisParser ParenthesisParser { get; }
        public KeywordParsers KeywordParsers { get; }
        public NameDefinitionParser NameDefinitionParser { get; }
        public PredicateParser PredicateParser { get; }
        public NameNonTokenParser NameNonTokenParser { get; }
        public VariableNameParser VariableNameParser { get; }
        public VariableParser VariableParser { get; }
        public TermParser TermParser { get; }
        public DomainVariableParser DomainVariableParser { get; }
        public TypeParser TypeParser { get; }
        public TypedListOfTypeParser TypedListOfTypeParser { get; }
        public TypedListOfConstantParser TypedListOfConstantParser { get; }
        public TypedListOfVariableParser TypedListOfVariableParser { get; }
        public TypedListOfObjectParser TypedListOfObjectParser { get; }
        public TypedListOfDomainVariableParser TypedListOfDomainVariableParser { get; }
        public AtomicFormulaSkeletonParser AtomicFormulaSkeletonParser { get; }
        public AtomicFormulaOfNameParser AtomicFormulaOfNameParser { get; }
        public AtomicFormulaOfTermParser AtomicFormulaOfTermParser { get; }
        public LiteralOfNameParser LiteralOfNameParser { get; }
        public LiteralOfTermParser LiteralOfTermParser { get; }
        public GoalDescriptionParser GoalDescriptionParser { get; }
        public VarsParser VarsParser { get; }
        public EffectParser EffectParser { get; }
        public RequirementsParser RequirementsParser { get; }
        public ExtensionDefinitionParser ExtensionDefinitionParser { get; }
        public RequirementsDefinitionParser DomainRequirementDefinitionParser { get; }
        public TypesDefinitionParser TypesDefinitionParser { get; }
        public ConstantsDefinitionParser ConstantsDefinitionParser { get; }
        public VariablesDefinitionParser VariablesDefinitionParser { get; }
        public PredicatesDefinitionParser PredicatesDefinitionParser { get; }
        public TimelessDefinitionParser TimelessDefinitionParser { get; }
        public SafetyDefinitionParser SafetyDefinitionParser { get; }
        public ActionDefinitionParser ActionDefinitionParser { get; }
        public AxiomParser AxiomParser { get; }
        public DomainDefinitionElementsParser DomainDefinitionElementsParser { get; }
        public DomainDefinitionParser DomainDefinitionParser { get; }
        public Parsing.ProblemParsers.RequirementsDefinitionParser ProblemRequirementDefinitionParser { get; }
        public InitialStateDefinitionParser InitialStateDefinitionParser { get; }
        public ObjectsDefinitionParser ObjectsDefinitionParser { get; }
        public GoalDefinitionParser GoalDefinitionParser { get; }
        public ProblemDefinitionElementsParser ProblemDefinitionElementsParser { get; }
        public ProblemDefinitionParser ProblemDefinitionParser { get; }
        public DefineDefinitionParser DefineDefinitionParser { get; }
    }
}
