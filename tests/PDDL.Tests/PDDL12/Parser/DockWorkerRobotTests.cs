using System.Linq;
using FluentAssertions;
using PDDL.PDDL12;
using PDDL.PDDL12.Abstractions;
using Xunit;

namespace PDDL.Tests.PDDL12.Parser
{
    public sealed class DockWorkerRobotTests : IClassFixture<ParserFixture>
    {
        private readonly PDDL12Parser _parser;

        public DockWorkerRobotTests(ParserFixture parserFixture)
        {
            _parser = parserFixture.Parser;
        }

        [Fact]
        public void DomainCanBeLoaded()
        {
            using var stream = typeof(DockWorkerRobotTests).Assembly.GetManifestResourceStream("PDDL.Tests.PDDL12.Data.Valid.DWR.domain.pddl")!;
            var definition = _parser.Parse(stream);
            definition.Should().ContainSingle()
                .Subject.Should().BeAssignableTo<IDomain>()
                .Subject.Name.Value.Should().Be("dock-worker-robot");

            var domain = definition.Single().As<IDomain>();

            domain.ClosedWorld.Should().BeTrue();
            domain.Requirements.Should().HaveCount(2);
            domain.Types.Should().HaveCount(5);
            domain.Predicates.Should().HaveCount(12);
            domain.Actions.Should().HaveCount(5);

            domain.Axioms.Should().HaveCount(0);
            domain.Constants.Should().HaveCount(0);
            domain.Extends.Should().HaveCount(0);
            domain.Safety.Should().HaveCount(0);
            domain.Timeless.Should().HaveCount(0);
            domain.Variables.Should().HaveCount(0);
        }

        [Theory]
        [InlineData("PDDL.Tests.PDDL12.Data.Valid.DWR.problem-1.pddl")]
        [InlineData("PDDL.Tests.PDDL12.Data.Valid.DWR.problem-2.pddl")]
        public void ProblemsCanBeLoaded(string resource)
        {
            using var stream = typeof(DockWorkerRobotTests).Assembly.GetManifestResourceStream(resource)!;
            var definition = _parser.Parse(stream);
            definition.Should()
                .ContainSingle()
                .Subject.Should().BeAssignableTo<IProblem>()
                .Subject.Domain.Value.Should().Be("dock-worker-robot");
        }
    }
}
