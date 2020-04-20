using System;
using System.Runtime.Serialization;

namespace PDDL.Parser
{
    /// <summary>
    /// Class PDDLSyntaxException.
    /// </summary>
    [Serializable]
    public class PddlSyntaxException : PddlParserException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PddlSyntaxException"/> class.
        /// </summary>
        public PddlSyntaxException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PddlSyntaxException" /> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public PddlSyntaxException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PddlSyntaxException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public PddlSyntaxException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PddlSyntaxException" /> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected PddlSyntaxException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
