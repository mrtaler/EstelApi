using System;

namespace EstelApi.Application.ApplicationCqrs
{
    using System.Threading;
    using System.Threading.Tasks;

    using FluentValidation;

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
