using System;
using JetBrains.Annotations;

namespace PDDL.Model.PDDL12
{
    /// <summary>
    /// Class Variable. This class cannot be inherited.
    /// </summary>
    public class Variable : IVariable
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        [NotNull]
        public IName Name { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Variable"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <exception cref="ArgumentNullException">The value of 'name' and 'type' cannot be null. </exception>
        public Variable(IName name)
        {
            if(ReferenceEquals(name, null)) throw new ArgumentNullException("name", "name must not be null");

            Name = name;
        }
        
        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return String.Format("?{0}", Name);
        }
    }
}
