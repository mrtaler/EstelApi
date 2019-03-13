namespace EstelApi.CrossCutting.Bus
{
    using System.Threading.Tasks;

    public interface ITopicClient
    {
        Task SendAsync<TMessage>(TMessage message) where TMessage : IBusTopicMessage;
    }
}