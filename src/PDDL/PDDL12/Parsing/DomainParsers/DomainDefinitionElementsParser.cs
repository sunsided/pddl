using System.Collections.Generic;
using System.Linq;
using PDDL.PDDL12.Abstractions.Domains;
using Sprache;

namespace PDDL.PDDL12.Parsing.DomainParsers
{
    /// <summary>
    /// Class DomainDefinitionElementParser.
    /// </summary>
    internal sealed class DomainDefinitionElementsParser : ParserBase<IReadOnlyList<IDomainDefinitionElement>>
    {
        public DomainDefinitionElementsParser(
            ExtensionDefinitionParser extensionDefinitionParser,
            RequirementsDefinitionParser requirementsDefinitionParser,
            TypesDefinitionParser typesDefinitionParser,
            ConstantsDefinitionParser constantsDefinitionParser,
            VariablesDefinitionParser variablesDefinitionParser,
            PredicatesDefinitionParser predicatesDefinitionParser,
            TimelessDefinitionParser timelessDefinitionParser,
            SafetyDefinitionParser safetyDefinitionParser,
            ActionDefinitionParser actionDefinitionParser,
            AxiomParser axiomParser)
        {
            Parser = from matches in
                    extensionDefinitionParser.Parser
                        .Or<IDomainDefinitionElement>(requirementsDefinitionParser)
                        .Or(typesDefinitionParser)
                        .Or(constantsDefinitionParser)
                        .Or(variablesDefinitionParser)
                        .Or(predicatesDefinitionParser)
                        .Or(timelessDefinitionParser)
                        .Or(safetyDefinitionParser)
                        .Or(actionDefinitionParser)
                        .Or(axiomParser)
                        .Many()
                select matches.ToList();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IReadOnlyList<IDomainDefinitionElement>> Parser { get; }
    }
}
