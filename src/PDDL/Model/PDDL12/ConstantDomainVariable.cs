using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class ConstantDomainVariable.
    /// </summary>
    internal sealed class ConstantDomainVariable : DomainVariable, IConstantDomainVariable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantDomainVariable" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException">value</exception>
        /// <exception cref="ArgumentNullException">value</exception>
        public ConstantDomainVariable([NotNull] IName name, IValue value)
            : base(name)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public IValue Value { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => $"{Name} = {Value}";
    }
}
