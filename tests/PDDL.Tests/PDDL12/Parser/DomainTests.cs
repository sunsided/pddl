using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Abstractions;
using Xunit;

namespace PDDL.Tests.PDDL12.Parser
{
    public sealed class DomainTests : IClassFixture<ParserFixture>
    {
        private readonly PDDL12Parser _parser;

        public DomainTests(ParserFixture parserFixture)
        {
            _parser = parserFixture.Parser;
        }

        [Theory]
        [InlineData("PDDL.Tests.PDDL12.Data.Valid.Generic.domain-empty.pddl")]
        [InlineData("PDDL.Tests.PDDL12.Data.Valid.Generic.domain-requirements-only.pddl")]
        [InlineData("PDDL.Tests.PDDL12.Data.Valid.Generic.domain-types-only.pddl")]
        public void DomainsCanBeLoaded(string resource)
        {
            using var stream = typeof(DockWorkerRobotTests).Assembly.GetManifestResourceStream(resource)!;
            // ReSharper disable once AccessToDisposedClosure
            System.Action parser = () => _parser.Parse(stream);
            parser.Should().NotThrow();
        }
    }
}
