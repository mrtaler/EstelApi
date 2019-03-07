using System.Collections.Generic;
using System.Linq;
using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Estel.Services.Api.Controllers
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler notifications;
        private readonly IMediator mediator;

        protected ApiController(INotificationHandler<DomainNotification> notifications,
            IMediator mediator)
        {
            this.notifications = (DomainNotificationHandler)notifications;
            this.mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => this.notifications.GetNotifications();

        protected bool IsValidOperation()
        {
            return (!this.notifications.HasNotifications());
        }

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

        protected void NotifyModelStateErrors()
        {
            var erros = this.ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                this.NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            this.mediator.Publish(new DomainNotification(code, message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.NotifyError(result.ToString(), error.Description);
            }
        }
    }
}
