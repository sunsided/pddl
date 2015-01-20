using System;
using JetBrains.Annotations;

namespace PDDL.Model.Pddl12.Types
{
    /// <summary>
    /// Class TypeBase.
    /// </summary>
    public abstract class TypeBase : IType
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public IName Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomType"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' cannot be null. </exception>
        protected TypeBase([NotNull] IName name)
        {
            if (ReferenceEquals(name, null)) throw new ArgumentNullException("name", "type name must not be null");
            Name = name;
        }

        /// <summary>
        /// Determines whether the specified <see cref="CustomType" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="CustomType" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        private bool Equals([NotNull] TypeBase other)
        {
            return Name.Equals(other.Name);
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
            return obj is TypeBase && Equals((TypeBase)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Name.ToString();
        }
    }
}
