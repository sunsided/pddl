using System;
using JetBrains.Annotations;
using Object = PDDL.Model.Pddl12.Types.Object;

namespace PDDL.Model.Pddl12
{
    /// <summary>
    /// Class Parameter.
    /// </summary>
    public class Parameter : IParameter
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Name { get; private set; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>The type.</value>
        public IType Type { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="type">The type.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'type' cannot be null. </exception>
        public Parameter([NotNull] IName name, [NotNull] IType type)
        {
            if (ReferenceEquals(name, null)) throw new ArgumentNullException("name", "name must not be null");
            if (ReferenceEquals(type, null)) throw new ArgumentNullException("type", "type must not be null");

            Name = name;
            Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'type' cannot be null.</exception>
        public Parameter([NotNull] IName name)
            : this(name, new Object())
        {
        }

        /// <summary>
        /// Determines whether the specified <see cref="Parameter" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="Parameter" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        protected bool Equals([NotNull] Parameter other)
        {
            return Name.Equals(other.Name) && Type.Equals(other.Type);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public override bool Equals([CanBeNull] object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Parameter) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Name.GetHashCode()*397) ^ Type.GetHashCode();
            }
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
