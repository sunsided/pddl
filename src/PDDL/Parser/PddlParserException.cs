using System;
using System.Runtime.Serialization;

namespace PDDL.Parser
{
    /// <summary>
    /// Class PDDLParserException.
    /// </summary>
    [Serializable]
    public class PddlParserException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PddlParserException"/> class.
        /// </summary>
        public PddlParserException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PddlParserException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PddlParserException(string? message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PddlParserException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="inner">The inner exception.</param>
        public PddlParserException(string? message, Exception? inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PddlParserException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected PddlParserException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
