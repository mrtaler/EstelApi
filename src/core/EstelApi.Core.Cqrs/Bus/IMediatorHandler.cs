//using System.Threading.Tasks;
//using EstelApi.Core.Cqrs.Commands;
//using EstelApi.Core.Cqrs.Events;

//namespace EstelApi.Core.Cqrs.Bus
//{

//    public interface IMediatorHandler
//    {
//        Task<TResponse> SendCommand<TEntity>(TEntity command)
//            where TEntity : ICommand
//            where TResponse : class;

//        Task RaiseEvent<T>(T @event) where T : IVersionedEvent;
//    }
//}
