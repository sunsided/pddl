using PDDL.PDDL12;

namespace PDDL.Tests.PDDL12.Parser
{
    public sealed class ParserFixture
    {
        public PDDL12Parser Parser { get; } = PDDL12Parser.Create();
    }
}
