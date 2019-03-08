namespace Estel.Services.Api.Extension.Exception
{
    using System;
    using System.Runtime.Serialization;

    /// <inheritdoc />
    public abstract class ApiErrorException : Exception
    {
        /// <inheritdoc />
        protected ApiErrorException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        protected ApiErrorException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc />
        protected ApiErrorException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets user-visible description of the error.
        /// </summary>
        public abstract string Description { get; }
    }
}