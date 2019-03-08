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
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        /// <summary>
        /// The notifications.
        /// </summary>
        private List<DomainNotification> notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainNotificationHandler"/> class.
        /// </summary>
        public DomainNotificationHandler()
        {
            this.notifications = new List<DomainNotification>();
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task Handle(DomainNotification message, CancellationToken cancellationToken)
        {
            this.notifications.Add(message);

            return Task.CompletedTask;
        }

        /// <summary>
        /// The get notifications.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.List`1"/>.
        /// </returns>
        public virtual List<DomainNotification> GetNotifications()
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
            this.notifications = new List<DomainNotification>();
        }
    }
}