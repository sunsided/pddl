using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12
{
    public class Variable : IVariable
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        public IName Name { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        [NotNull]
        public IType Type { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Variable"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'type' cannot be null. </exception>
        public Variable(IName name, IType type)
        {
            if(ReferenceEquals(name, null)) throw new ArgumentNullException("name", "name must not be null");
            if (ReferenceEquals(type, null)) throw new ArgumentNullException("type", "type must not be null");

            Name = name;
            Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Variable" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null.</exception>
        public Variable(IName name)
            : this(name, Types.Object.Default)
        {
        }
    }
}
