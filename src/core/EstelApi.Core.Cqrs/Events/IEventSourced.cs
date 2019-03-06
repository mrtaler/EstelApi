using System;
using System.Collections.Generic;

namespace EstelApi.Core.Cqrs.Events
{
    public interface IEventSourced
    {
        Guid Id { get; }

        long Version { get; }

        IEnumerable<IVersionedEvent> Events { get; }
    }
}