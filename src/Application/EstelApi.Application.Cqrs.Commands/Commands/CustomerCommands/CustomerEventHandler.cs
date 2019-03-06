using EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EstelApi.Core.Seedwork.CoreCqrs.Events;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands
{
    public class CustomerEventHandler :
        INotificationHandler<CustomerRegisteredEvent>,
        INotificationHandler<CustomerUpdatedEvent>,
        INotificationHandler<CustomerRemovedEvent>
    {
        private readonly IEventStore _eventStore;
        public CustomerEventHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;

        }
        public Task Handle(CustomerUpdatedEvent message, CancellationToken cancellationToken)
        {
            if (!message.MessageType.Equals("DomainNotification"))
                          _eventStore?.Save(message);


                return Task.CompletedTask;
        }

        public Task Handle(CustomerRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            if (!message.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(message);
            return Task.CompletedTask;
        }

        public Task Handle(CustomerRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail
            if (!message.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(message);
            return Task.CompletedTask;
        }
    }
}
