using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;
using Serilog.Events;

namespace Estel.Services.Api.Extension.Exception
{
    /// <summary>
    /// Exception filter for handling unexpected and expected exceptions that passes through to the framework.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger _log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
        /// </summary>
        public ApiExceptionFilterAttribute(ILogger log)
        {
            _log = log;
        }

        /// <inheritdoc />
        public override void OnException(ExceptionContext context)
        {
            ApiError error;
            if (context.Exception is ApiErrorException ex)
            {
                error = new ApiError(ex.Description, ex.GetBaseException());
                _log.ApiError(error);
            }
            else
            {
                error = new ApiError("Unknown error", context.Exception);
                _log.ApiError(error, LogEventLevel.Error);
            }

            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(error);
            base.OnException(context);
        }
    }
}