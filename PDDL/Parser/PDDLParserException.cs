using System;
using System.Runtime.Serialization;

namespace PDDL.Parser
{
    /// <summary>
    /// Class PDDLParserException.
    /// </summary>
    [Serializable]
    public class PDDLParserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PDDLParserException"/> class.
        /// </summary>
        public PDDLParserException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PDDLParserException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PDDLParserException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PDDLParserException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public PDDLParserException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PDDLParserException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected PDDLParserException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
