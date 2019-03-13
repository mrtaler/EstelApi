namespace EstelApi.CrossCutting.Bus
{
    using System.Text;

    using Microsoft.Azure.ServiceBus;

    using Newtonsoft.Json;

    public class MessageFactory : IMessageFactory
    {
        public Message CreateMessage<TMessage>(TMessage message) where TMessage : IBusMessage
        {
            var json = JsonConvert.SerializeObject(message);
            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(json));

            if (message.ScheduledEnqueueTimeUtc.HasValue)
                serviceBusMessage.ScheduledEnqueueTimeUtc = message.ScheduledEnqueueTimeUtc.Value;

            return serviceBusMessage;
        }
    }
}