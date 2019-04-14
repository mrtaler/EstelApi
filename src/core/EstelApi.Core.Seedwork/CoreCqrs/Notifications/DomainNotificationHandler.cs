namespace EstelApi.Core.Seedwork.CoreCqrs.Notifications
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using MediatR;

    /// <summary>
    /// The domain notification handler.
    /// </summary>
    public class DomainEventHandler : INotificationHandler<DomainEvent>
    {
        /// <summary>
        /// The notifications.
        /// </summary>
        private List<DomainEvent> notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainEventHandler"/> class.
        /// </summary>
        public DomainEventHandler()
        {
            this.notifications = new List<DomainEvent>();
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="notification">
        /// The notification.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Handle(DomainEvent notification, CancellationToken cancellationToken)
        {
            this.notifications.Add(notification);

            return Task.CompletedTask;
        }

        /// <summary>
        /// The get notifications.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.List`1"/>.
        /// </returns>
        public virtual List<DomainEvent> GetNotifications()
        {
            return this.notifications;
        }

        /// <summary>
        /// The has notifications.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public virtual bool HasNotifications()
        {
            return this.GetNotifications().Any();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.notifications = new List<DomainEvent>();
        }
    }
}