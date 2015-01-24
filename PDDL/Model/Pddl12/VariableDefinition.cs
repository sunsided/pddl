using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class VariableDefinition.
    /// </summary>
    public class VariableDefinition : IVariableDefinition
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        public IVariable Value { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        [NotNull]
        public IType Type { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableDefinition"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'type' cannot be null. </exception>
        public VariableDefinition(IVariable name, IType type)
        {
            if(ReferenceEquals(name, null)) throw new ArgumentNullException("name", "name must not be null");
            if (ReferenceEquals(type, null)) throw new ArgumentNullException("type", "type must not be null");

            Value = name;
            Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VariableDefinition" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null.</exception>
        public VariableDefinition(IVariable name)
            : this(name, Types.DefaultType.Default)
        {
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Format("{0} - {1}", Value, Type);
        }
    }
}
