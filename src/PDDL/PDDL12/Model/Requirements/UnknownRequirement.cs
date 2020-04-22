namespace PDDL.PDDL12.Model.Requirements
{
    /// <summary>
    /// A requirement unknown to the parser.
    /// </summary>
    internal sealed class UnknownRequirement : Requirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnknownRequirement"/> class.
        /// </summary>
        public UnknownRequirement(string value) : base(value)
        {
        }
    }
}
