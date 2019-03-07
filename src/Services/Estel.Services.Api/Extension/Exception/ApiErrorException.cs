using System.Runtime.Serialization;

namespace Estel.Services.Api.Extension.Exception
{
    using System;

    public abstract class ApiErrorException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorException"/> class.
        /// </summary>
        protected ApiErrorException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorException"/> class.
        /// </summary>
        protected ApiErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorException"/> class.
        /// </summary>
        protected ApiErrorException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiErrorException"/> class.
        /// </summary>
        protected ApiErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// A user-visible description of the error.
        /// </summary>
        public abstract string Description { get; }
    }
}