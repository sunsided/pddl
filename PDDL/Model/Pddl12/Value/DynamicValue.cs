using System.Globalization;

namespace PDDL.Model.PDDL12.Value
{
    /// <summary>
    /// Class DecimalValue. This class cannot be inherited.
    /// </summary>
    internal sealed class DynamicValue : IDynamicValue
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public dynamic Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicValue"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public DynamicValue(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DynamicValue" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="DynamicValue" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        private bool Equals(DynamicValue other)
        {
            return Value == other.Value;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is DynamicValue && Equals((DynamicValue)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
