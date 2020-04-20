using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class AtomicFormula.
    /// </summary>
    public class AtomicFormula<T> : IAtomicFormula<T>
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public IName Name { get; }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <value>The parameters.</value>
        public IReadOnlyList<T> Parameters { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicFormulaSkeleton"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'parameters' cannot be null. </exception>
        public AtomicFormula([NotNull] IName name, [NotNull] IReadOnlyList<T> parameters)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name), "name must not be null");
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters), "type must not be null");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AtomicFormulaSkeleton" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'parameters' cannot be null.</exception>
        public AtomicFormula([NotNull] IName name)
            : this(name, new T[0])
        {
        }

        /// <summary>
        /// Determines whether the specified <see cref="AtomicFormulaSkeleton" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="AtomicFormulaSkeleton" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        protected bool Equals([NotNull] AtomicFormula<T> other) => Name.Equals(other.Name) && Parameters.Equals(other.Parameters);

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((AtomicFormula<T>)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Name.GetHashCode()*397) ^ Parameters.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => Name.ToString();
    }
}
