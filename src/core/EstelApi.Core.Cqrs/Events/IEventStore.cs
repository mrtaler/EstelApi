namespace EstelApi.Core.Cqrs.Events
{
    public interface IEventStore
    {
        void Save<TEntity>(TEntity theEvent) where TEntity : IVersionedEvent;
    }
}
