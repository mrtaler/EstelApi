using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstelApi.Core.Seedwork.CoreCqrs.Events;
using EstelApi.Domain.DataAccessLayer.Context.Context;

using Microsoft.EntityFrameworkCore;

namespace EstelApi.Domain.DataAccessLayer.Context.Repository.EventSourcing
{
    public class EventStoreSqlRepository : IEventStoreRepository
    {
        private readonly EventStoreSqlContext context;

        public EventStoreSqlRepository(EventStoreSqlContext context)
        {
            this.context = context;
        }

        public Task<List<StoredEvent>> All(Guid aggregateId)
        {
            var t2 = this.context.StoredEvent.Where(e => e.AggregateId == aggregateId).ToListAsync();
            return t2;
        }

        public Task<int> Store(StoredEvent theEvent)
        {
            this.context.StoredEvent.Add(theEvent);
            return this.context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}