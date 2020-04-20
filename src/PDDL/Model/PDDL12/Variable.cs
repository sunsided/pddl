using System;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class Variable. This class cannot be inherited.
    /// </summary>
    internal sealed class Variable : IVariable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Variable"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'type' cannot be null. </exception>
        public Variable(IName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "name must not be null");
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Name { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => $"?{Name}";
    }
}
