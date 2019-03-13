namespace EstelApi.CrossCutting.Bus
{
    using System.Threading.Tasks;

    public interface IBusMessageDispatcher
    {
        Task DispatchAsync<TMessage>(TMessage message) where TMessage : IBusMessage;
    }
}