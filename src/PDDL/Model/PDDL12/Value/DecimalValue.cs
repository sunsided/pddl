using System.Globalization;

namespace PDDL.Model.PDDL12.Value
{
    /// <summary>
    /// Class DecimalValue. This class cannot be inherited.
    /// </summary>
    public class DecimalValue : IDecimalValue
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        public decimal Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DecimalValue"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public DecimalValue(decimal value)
        {
            Value = value;
        }

        /// <summary>
        /// Determines whether the specified <see cref="DecimalValue" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="DecimalValue" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        private bool Equals(DecimalValue other) => Value == other.Value;

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><see langword="true" /> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <see langword="false" />.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is DecimalValue && Equals((DecimalValue) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode() => Value.GetHashCode();

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString() => Value.ToString(CultureInfo.InvariantCulture);
    }
}
