namespace Estel.Services.Api.Extension.Exception
{
    using System;

    using Newtonsoft.Json;

    using Exception = System.Exception;

    /// <summary>
    /// The api error.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// The exception.
        /// </summary>
        private readonly Exception exception;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class. The error does not have a specific description.
        /// </summary>
        /// <param name="exception">
        /// The exception.
        /// </param>
        public ApiError(Exception exception)
            : this(exception.Message, exception)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class. The error does not have an exception that is associated with it.
        /// </summary>
        /// <param name="description">
        /// The description.
        /// </param>
        [JsonConstructor]
        public ApiError(string description)
            : this(description, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiError"/> class.
        /// </summary>
        /// <param name="description">Overall description of error explaining which part of system in general is broken</param>
        /// <param name="exception">The exception that caused the error</param>
        public ApiError(string description, Exception exception)
        {
            this.Description = description;
            this.Id = Guid.NewGuid();
            this.exception = exception;
        }

        /// <summary>
        /// Gets Overall description of error explaining which part of system in general is broken
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets Unique error ID for tracking purposes
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Returns a string representation of ApiError
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public override string ToString()
        {
            return $"[{this.Id}] {this.Description}";
        }

        /// <summary>
        /// Returns the exception that caused the error, if any
        /// </summary>
        /// <returns>
        /// The <see cref="Exception"/>.
        /// </returns>
        public Exception GetException()
        {
            return this.exception;
        }
    }
}
