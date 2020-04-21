using System.Collections.Generic;
using System.Linq;
using PDDL.PDDL12.Abstractions.Problems;
using Sprache;

namespace PDDL.PDDL12.Parsing.ProblemParsers
{
    /// <summary>
    /// Class ProblemDefinitionElementParser.
    /// </summary>
    internal sealed class ProblemDefinitionElementsParser : ParserBase<IReadOnlyList<IProblemDefinitionElement>>
    {
        public ProblemDefinitionElementsParser(
            RequirementsDefinitionParser requirementsDefinitionParser,
            InitialStateDefinitionParser initialStateDefinitionParser,
            ObjectsDefinitionParser objectsDefinitionParser,
            GoalDefinitionParser goalDefinitionParser
            )
        {
            Parser = from matches in
                    requirementsDefinitionParser.Parser
                        .Or<IProblemDefinitionElement>(initialStateDefinitionParser)
                        .Or(objectsDefinitionParser)
                        .Or(goalDefinitionParser)
                        .Many()
                select matches.ToList();
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public override Parser<IReadOnlyList<IProblemDefinitionElement>> Parser { get; }
    }
}
