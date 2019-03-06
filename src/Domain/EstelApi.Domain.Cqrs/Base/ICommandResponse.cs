﻿using System.Collections.Generic;
using FluentValidation.Results;

namespace EstelApi.Domain.Cqrs.Base
{
    public interface ICommandResponse
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
        IEnumerable<ValidationFailure> ValidationErrors { get; set; }
    }

    public interface ICommandResponse<TEntity> : ICommandResponse
    {
        TEntity Object { get; set; }
    }
}