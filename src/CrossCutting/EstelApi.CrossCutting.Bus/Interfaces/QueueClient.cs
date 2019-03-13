namespace EstelApi.CrossCutting.Bus
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.Azure.ServiceBus;
    using Microsoft.Extensions.Options;

    public class QueueClient : IQueueClient
    {
        private readonly IMessageFactory _messageFactory;
        private readonly string _connectionString;

        public QueueClient(IMessageFactory messageFactory, IOptions<ServiceBusConfiguration> serviceBusConfiguration)
        {
            this._messageFactory = messageFactory;
            this._connectionString = serviceBusConfiguration.Value.ConnectionString;
        }

        public async Task SendAsync<TMessage>(TMessage message) where TMessage : IBusQueueMessage
        {
            if (string.IsNullOrEmpty(message.QueueName))
                throw new ApplicationException("Queue name is mandatory");

            var client = new Microsoft.Azure.ServiceBus.QueueClient(new ServiceBusConnectionStringBuilder(this._connectionString)
                                                                        {
                                                                            EntityPath = message.QueueName
                                                                        });

            var serviceBusMessage = this._messageFactory.CreateMessage(message);

            await client.SendAsync(serviceBusMessage);

            await client.CloseAsync();
        }
    }
}