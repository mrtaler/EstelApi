using System.Collections.Generic;
using FluentValidation.Results;

namespace EstelApi.Domain.Cqrs.Base
{
    public class CommandResponse<TEntity> : ICommandResponse<TEntity>
    {
        public CommandResponse()
        {
            IsSuccess = false;
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