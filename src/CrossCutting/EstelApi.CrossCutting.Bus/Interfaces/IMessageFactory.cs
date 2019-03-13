namespace EstelApi.CrossCutting.Bus
{
    using Microsoft.Azure.ServiceBus;

    public interface IMessageFactory
    {
        Message CreateMessage<TMessage>(TMessage message) where TMessage : IBusMessage;
    }
}