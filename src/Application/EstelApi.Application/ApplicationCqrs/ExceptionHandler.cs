using System;
using System.Collections.Generic;
using System.Text;

namespace EstelApi.Application.ApplicationCqrs
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Commands;

    using FluentValidation;
    using FluentValidation.Results;

    using MediatR;

    using Serilog;

    public class ExceptionHandler<TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <param name="next">
        /// The next.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);

            try
            {
                response = response = await next();
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Log.Error(
                    request.ToString(), response, ex);
            }

            return response;
        }
    }
}
