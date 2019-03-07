namespace EstelApi.Application.ApplicationCqrs.Base
{
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;

    using MediatR;

    public class QueryHandler
    {
        private readonly IQueryableUnitOfWork uow;
        private readonly IMediator bus;
        private readonly DomainNotificationHandler notifications;

        public QueryHandler(IQueryableUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications)
        {
            this.uow = uow;
            this.notifications = (DomainNotificationHandler)notifications;
            this.bus = bus;
        }

        // todo transfer in to mediatr pipeline
        /*  protected void NotifyValidationErrors(ICommand message)
          {
              foreach (var error in message.ValidationResult.Errors)
              {
                  _bus.Publish(new DomainNotification(message.GetType().Name, error.ErrorMessage));
              }
          }*/
        public bool Commit()
        {
            if (this.notifications.HasNotifications()) return false;
            if (this.uow.Commit()) return true;

            this.bus.Publish(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
