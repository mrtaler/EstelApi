namespace EstelApi.Domain.DataAccessLayer.Context.Context.Base
{
    using System;
    using System.Runtime.Serialization;

    using Newtonsoft.Json;

    /// <inheritdoc />
    public class DatabaseException : Exception
    {
        /// <inheritdoc />
        public DatabaseException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public DatabaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <inheritdoc />
        public DatabaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Gets user-visible description of the error.
        /// </summary>
        public virtual string Description { get; }
    }
}