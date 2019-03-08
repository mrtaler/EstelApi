namespace EstelApi.Domain.DataAccessLayer.Context.EventSourcing
{
    using EstelApi.Core.Seedwork.CoreCqrs.Events;
    using EstelApi.Core.Seedwork.Interfaces;

    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    /// The sql event store.
    /// </summary>
    public class SqlEventStore : IEventStore
    {
        /// <summary>
        /// The event store repository.
        /// </summary>
        private readonly IEventStoreRepository eventStoreRepository;

        /// <summary>
        /// The user.
        /// </summary>
        private readonly IUser user;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlEventStore"/> class.
        /// </summary>
        /// <param name="eventStoreRepository">
        /// The event store repository.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        public SqlEventStore(IEventStoreRepository eventStoreRepository, IUser user)
        {
            this.eventStoreRepository = eventStoreRepository;
            this.user = user;
        }

        /// <inheritdoc />
        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="theEvent">
        /// The the event.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        public void Save<T>(T theEvent) where T : Event
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
