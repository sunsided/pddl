using System;
using JetBrains.Annotations;
using PDDL.Model.PDDL12.Types;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class DomainVariable.
    /// </summary>
    internal class DomainVariable : IDomainVariable
    {
        /// <summary>
        /// The type
        /// </summary>
        [NotNull]
        private IType _type = DefaultType.Default;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainVariable" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="System.ArgumentNullException">name</exception>
        public DomainVariable([NotNull] IName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }


        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Name { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        /// <exception cref="ArgumentNullException">The value of 'value' cannot be null. </exception>
        public IType Type
        {
            get => _type;
            set => _type = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => $"{Name} - {Type}";
    }
}
