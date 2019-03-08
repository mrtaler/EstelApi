namespace EstelApi.Application.ApplicationCqrs.Base
{
    using System.Collections.Generic;

    using FluentValidation.Results;

    /// <summary>
    /// The CommandResponse interface.
    /// </summary>
    public interface ICommandResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether is success.
        /// </summary>
        bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets the validation errors.
        /// </summary>
        IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }

    /// <inheritdoc />
    /// <summary>
    /// The CommandResponse interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// </typeparam>
    public interface ICommandResponse<TEntity> : ICommandResponse
    {
        /// <summary>
        /// Gets or sets the object.
        /// </summary>
        TEntity Object { get; set; }
    }
}