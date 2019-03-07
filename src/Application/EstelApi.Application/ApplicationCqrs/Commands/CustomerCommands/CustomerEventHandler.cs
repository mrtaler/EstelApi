namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Events;
    using EstelApi.Core.Seedwork.CoreCqrs.Events;

    using MediatR;

    /// <summary>
    /// The customer event handler.
    /// </summary>
    public class CustomerEventHandler :
        INotificationHandler<CustomerRegisteredEvent>,
        INotificationHandler<CustomerUpdatedEvent>,
        INotificationHandler<CustomerRemovedEvent>
    {
        /// <summary>
        /// The event store.
        /// </summary>
        private readonly IEventStore eventStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerEventHandler"/> class.
        /// </summary>
        /// <param name="eventStore">
        /// The event store.
        /// </param>
        public CustomerEventHandler(IEventStore eventStore)
        {
            this.eventStore = eventStore;
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
        public Task Handle(CustomerUpdatedEvent message, CancellationToken cancellationToken)
        {
            var msg = message.MessageType;
            if (!message.MessageType.Equals("DomainNotification"))
            {
                this.eventStore?.Save(message);
            }

            return Task.CompletedTask;
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
        public Task Handle(CustomerRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            if (!message.MessageType.Equals("DomainNotification"))
            {
                this.eventStore?.Save(message);
            }

            return Task.CompletedTask;
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
        public Task Handle(CustomerRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail
            if (!message.MessageType.Equals("DomainNotification"))
            {
                this.eventStore?.Save(message);
            }

            return Task.CompletedTask;
        }
    }
}
