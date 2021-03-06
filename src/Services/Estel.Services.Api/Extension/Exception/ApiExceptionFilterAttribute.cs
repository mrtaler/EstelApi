﻿namespace Estel.Services.Api.Extension.Exception
{
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Serilog;
    using Serilog.Events;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// Exception filter for handling unexpected and expected exceptions that passes through to the framework.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// The log.
        /// </summary>
        private readonly ILogger log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiExceptionFilterAttribute"/> class.
        /// </summary>
        /// <param name="log">
        /// The log.
        /// </param>
        public ApiExceptionFilterAttribute(ILogger log)
        {
            this.log = log;
        }

        /// <inheritdoc />
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            ApiError error;
            switch (context.Exception)
            {
                case ApiErrorException ex:
                    error = new ApiError(ex.Description, ex.GetBaseException());
                    this.log.ApiError(error);
                    break;
                case DatabaseException dbexep:
                    error = new ApiError(dbexep.Message, dbexep.GetBaseException());
                    this.log.ApiError(error);
                    break;
                default:
                    error = new ApiError("Unknown error", context.Exception);
                    this.log.ApiError(error, LogEventLevel.Error);
                    break;
            }



            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new JsonResult(error);
            await base.OnExceptionAsync(context);
        }
    }
}