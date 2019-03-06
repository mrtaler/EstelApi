namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    public interface IEventStore
    {
        void Save<TEntity>(TEntity theEvent) where TEntity : IVersionedEvent;
    }
}
