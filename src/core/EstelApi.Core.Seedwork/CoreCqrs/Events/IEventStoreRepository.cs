namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// The EventStoreRepository interface.
    /// </summary>
    public interface IEventStoreRepository : IDisposable
    {
        /// <summary>
        /// The store.
        /// </summary>
        /// <param name="theEvent">
        /// The the event.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<int> Store(StoredEvent theEvent);

        /// <summary>
        /// The all.
        /// </summary>
        /// <param name="aggregateId">
        /// The aggregate id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<List<StoredEvent>> All(Guid aggregateId);
    }
}
