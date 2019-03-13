namespace EstelApi.CrossCutting.Bus
{
    using System.Threading.Tasks;

    public interface IQueueClient
    {
        Task SendAsync<TMessage>(TMessage message) where TMessage : IBusQueueMessage;
    }
}
