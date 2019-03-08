namespace EstelApi.Application.ApplicationCqrs.Base
{
    using System.Collections.Generic;

    using FluentValidation.Results;

    /// <summary>
    /// The command response.
    /// </summary>
    /// <typeparam name="TEntity">Responsed entity
    /// </typeparam>
    public class CommandResponse<TEntity> : ICommandResponse<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandResponse{TEntity}"/> class.
        /// </summary>
        public CommandResponse()
        {
            this.IsSuccess = false;
        }

        /// <inheritdoc />
        public bool IsSuccess { get; set; }

        /// <inheritdoc />
        public TEntity Object { get; set; }

        /// <inheritdoc />
        public IEnumerable<ValidationFailure> ValidationErrors { get; set; }

        /// <inheritdoc />
        public string Message { get; set; }
    }
}