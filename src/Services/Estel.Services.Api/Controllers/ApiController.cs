namespace Estel.Services.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;

    using MediatR;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    /// <inheritdoc />
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        /// <summary>
        /// The notifications.
        /// </summary>
        private readonly DomainNotificationHandler notifications;

        /// <summary>
        /// The mediator.
        /// </summary>
        private readonly IMediator mediator;

        /// <inheritdoc />
        protected ApiController(
            INotificationHandler<DomainNotification> notifications,
            IMediator mediator)
        {
            this.notifications = (DomainNotificationHandler)notifications;
            this.mediator = mediator;
        }

        /// <summary>
        /// The notifications.
        /// </summary>
        protected IEnumerable<DomainNotification> Notifications => this.notifications.GetNotifications();

        /// <summary>
        /// The is valid operation.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected bool IsValidOperation() => !this.notifications.HasNotifications();

        /// <summary>
        /// The response.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <returns>
        /// The <see cref="IActionResult"/>.
        /// </returns>
        protected new IActionResult Response(object result = null)
        {
            if (this.IsValidOperation())
            {
                return this.Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return this.BadRequest(new
            {
                success = false,
                errors = this.notifications.GetNotifications().Select(n => n.Value)
            });
        }

        /// <summary>
        /// The notify model state errors.
        /// </summary>
        protected void NotifyModelStateErrors()
        {
            var errors = this.ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in errors)
            {
                var errorsMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                this.NotifyError(string.Empty, errorsMsg);
            }
        }

        /// <summary>
        /// The notify error.
        /// </summary>
        /// <param name="code">
        /// The code.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        protected void NotifyError(string code, string message)
        {
            this.mediator.Publish(new DomainNotification(code, message));
        }

        /// <summary>
        /// The add identity errors.
        /// </summary>
        /// <param name="result">
        /// The result.
        /// </param>
        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.NotifyError(result.ToString(), error.Description);
            }
        }
    }
}
