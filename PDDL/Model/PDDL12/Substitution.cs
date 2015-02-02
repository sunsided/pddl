using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class Substitution. This class cannot be inherited.
    /// </summary>
    public sealed class Substitution : ISubstitution
    {
        /// <summary>
        /// Gets the variable.
        /// </summary>
        /// <value>The variable.</value>
        public IVariableDefinition Variable { get; private set; }

        /// <summary>
        /// Gets the object.
        /// </summary>
        /// <value>The object.</value>
        public ITerm Object { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Substitution"/> class.
        /// </summary>
        /// <param name="variable">The variable.</param>
        /// <param name="object">The object.</param>
        /// <exception cref="ArgumentNullException">The value of 'variable' or 'object' cannot be null. </exception>
        public Substitution([NotNull] IVariableDefinition variable, [NotNull] ITerm @object)
        {
            if (ReferenceEquals(variable, null)) throw new ArgumentNullException("variable");
            if (ReferenceEquals(@object, null)) throw new ArgumentNullException("object");
            Variable = variable;
            Object = @object;
        }

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns><see langword="true" /> if XXXX, <see langword="false" /> otherwise.</returns>
        private bool Equals(Substitution other)
        {
            return Variable.Equals(other.Variable) && Object.Equals(other.Object);
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
            return obj is Substitution && Equals((Substitution) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Variable.GetHashCode()*397) ^ Object.GetHashCode();
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Format("{0} := {1}", Variable, Object);
        }
    }
}
