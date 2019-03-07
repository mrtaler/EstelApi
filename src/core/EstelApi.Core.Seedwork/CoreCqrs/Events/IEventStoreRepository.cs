using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    public interface IEventStoreRepository : IDisposable
    {
        Task<int> Store(StoredEvent theEvent);
        Task<List<StoredEvent>> All(Guid aggregateId);
    }
}
