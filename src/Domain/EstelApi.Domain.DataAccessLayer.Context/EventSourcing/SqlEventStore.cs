using EstelApi.Core.Seedwork.CoreCqrs.Events;
using EstelApi.Core.Seedwork.Interfaces;
using Newtonsoft.Json;

namespace EstelApi.Domain.DataAccessLayer.Context.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository eventStoreRepository;
        private readonly IUser user;

        public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
            this.eventStoreRepository = eventStoreRepository;
            this.user = user;
        }

        public  void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                this.user.Name);

            this.eventStoreRepository.Store(storedEvent);
        }
    }
}
