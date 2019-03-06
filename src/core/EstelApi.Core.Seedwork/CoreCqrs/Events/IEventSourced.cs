using System;
using System.Collections.Generic;

namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    public interface IEventSourced
    {
        Guid Id { get; }

        long Version { get; }

        IEnumerable<IVersionedEvent> Events { get; }
    }
}