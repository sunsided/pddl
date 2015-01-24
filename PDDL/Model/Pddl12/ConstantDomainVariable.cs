using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Class ConstantDomainVariable.
    /// </summary>
    public class ConstantDomainVariable : DomainVariable, IConstantDomainVariable
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public IValue Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantDomainVariable" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <param name="value">The value.</param>
        /// <exception cref="System.ArgumentNullException">value</exception>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null.</exception>
        public ConstantDomainVariable([NotNull] IName name, IValue value)
            : base(name)
        {
            if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
            Value = value;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Format("{0} = {1}", Name, Value);
        }
    }
}
