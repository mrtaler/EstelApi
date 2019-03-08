namespace EstelApi.Domain.DataAccessLayer.Context.Repository.EventSourcing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EstelApi.Core.Seedwork.CoreCqrs.Events;
    using EstelApi.Domain.DataAccessLayer.Context.Context;

    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc />
    /// <summary>
    /// The event store sql repository.
    /// </summary>
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        /// <summary>
        /// The context.
        /// </summary>
        private readonly EventStoreSqlContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventStoreSqlRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            this.context = context;
        }

        /// <inheritdoc />
        /// <summary>
        /// The all.
        /// </summary>
        /// <param name="aggregateId">
        /// The aggregate id.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public Task<List<StoredEvent>> All(Guid aggregateId)
        {
            var t2 = this.context.StoredEvent.Where(e => e.AggregateId == aggregateId).ToListAsync();
            return t2;
        }

        /// <inheritdoc />
        /// <summary>
        /// The store.
        /// </summary>
        /// <param name="theEvent">
        /// The the event.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public Task<int> Store(StoredEvent theEvent)
        {
            this.context.StoredEvent.Add(theEvent);
            return this.context.SaveChangesAsync();
        }

        /// <inheritdoc />
        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}