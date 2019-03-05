using System;
using System.Collections.Generic;

namespace EstelApi.Core.Cqrs.Events
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
