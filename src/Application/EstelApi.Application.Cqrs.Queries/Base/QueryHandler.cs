using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using MediatR;

namespace EstelApi.Application.Cqrs.Queries.Base
{
    public class QueryHandler
    {
        private readonly IQueryableUnitOfWork _uow;
        private readonly IMediator _bus;
        private readonly DomainNotificationHandler _notifications;

        public QueryHandler(IQueryableUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
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
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

            _bus.Publish(new DomainNotification("Commit", "We had a problem during saving your data."));
            return false;
        }
    }
}
