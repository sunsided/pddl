using System;
using JetBrains.Annotations;
using PDDL.Model.PDDL12.Types;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class DomainVariable.
    /// </summary>
    public class DomainVariable : IDomainVariable
    {
        /// <summary>
        /// The type
        /// </summary>
        [NotNull]
        private IType _type = DefaultType.Default;

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Name { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        [NotNull]
        public IType Type
        {
            get { return _type; }
            set
            {
                if (ReferenceEquals(value, null)) throw new ArgumentNullException("value");
                _type = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainVariable" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        public DomainVariable([NotNull] IName name)
        {
            if (ReferenceEquals(name, null)) throw new ArgumentNullException("name");
            Name = name;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Format("{0} - {1}", Name, Type);
        }
    }
}
