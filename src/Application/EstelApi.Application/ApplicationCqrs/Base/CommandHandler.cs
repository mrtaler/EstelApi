namespace EstelApi.Application.ApplicationCqrs.Base
{
    using System.Threading.Tasks;

    using EstelApi.Core.Seedwork.CoreCqrs.Commands;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <summary>
    /// The command handler.
    /// </summary>
    public class CommandHandler
    {
        /// <summary>
        /// The bus.
        /// </summary>
        protected readonly IMediator Bus;

        /// <summary>
        /// The uow.
        /// </summary>
        private readonly IQueryableUnitOfWork uow;

        /// <summary>
        /// The notifications.
        /// </summary>
        private readonly DomainEventHandler notifications;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandHandler"/> class.
        /// </summary>
        /// <param name="uow">
        /// The uow.
        /// </param>
        /// <param name="bus">
        /// The bus.
        /// </param>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        public CommandHandler(IQueryableUnitOfWork uow, IMediator bus, INotificationHandler<DomainEvent> notifications)
        {
            this.uow = uow;
            this.notifications = (DomainEventHandler)notifications;
            this.Bus = bus;
        }

        /// <summary>
        /// The commit.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public async Task<bool> CommitAsync()
        {
            if (this.notifications.HasNotifications())
            {
                return false;
            }

            if (this.uow.Commit())
            {
                return true;
            }

            await this.Bus.Publish(new DomainEvent("Commit", "We had a problem during saving your data.")).ConfigureAwait(false);
            return false;
        }
    }
}
