namespace EstelApi.CrossCutting.Bus
{
    using System.Threading.Tasks;

    public class TopicClient : ITopicClient
    {
        private readonly IMessageFactory _messageFactory;
        private readonly string _connectionString;

        public TopicClient(IMessageFactory messageFactory, IOptions<ServiceBusConfiguration> serviceBusConfiguration)
        {
            this._messageFactory = messageFactory;
            this._connectionString = serviceBusConfiguration.Value.ConnectionString;
        }

        public async Task SendAsync<TMessage>(TMessage message) where TMessage : IBusTopicMessage
        {
            if (string.IsNullOrEmpty(message.TopicName))
                throw new ApplicationException("Topic name is mandatory");

            var client = new Microsoft.Azure.ServiceBus.TopicClient(new ServiceBusConnectionStringBuilder(this._connectionString)
                                                                        {
                                                                            EntityPath = message.TopicName
                                                                        });

            var serviceBusMessage = this._messageFactory.CreateMessage(message);

            await client.SendAsync(serviceBusMessage);

            await client.CloseAsync();
        }
    }
}