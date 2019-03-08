namespace EstelApi.Application.ApplicationCqrs.Base
{
    using System.Collections.Generic;

    using FluentValidation.Results;

    public class CommandResponse<TEntity> : ICommandResponse<TEntity>
    {
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