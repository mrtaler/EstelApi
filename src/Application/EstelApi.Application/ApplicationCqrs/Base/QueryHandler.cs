namespace EstelApi.Application.ApplicationCqrs.Base
{
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <summary>
    /// The query handler.
    /// </summary>
    public class QueryHandler
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
        /// Initializes a new instance of the <see cref="QueryHandler"/> class.
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
        public QueryHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications)
        {
            this.uow = uow;
            this.notifications = (DomainEventHandler)notifications;
            this.Bus = bus;
        }
    }
}
