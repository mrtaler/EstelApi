using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace EstelApi.Core.Seedwork.CoreCqrs.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> notifications;

        public DomainNotificationHandler()
        {
            this.notifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            this.notifications.Add(message);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> GetNotifications()
        {
            return this.notifications;
        }

        public virtual bool HasNotifications()
        {
            return this.GetNotifications().Any();
        }

        public void Dispose()
        {
            this.notifications = new List<DomainNotification>();
        }
    }
}