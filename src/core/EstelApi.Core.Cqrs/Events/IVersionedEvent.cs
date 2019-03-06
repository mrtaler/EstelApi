using System;
using MediatR;

namespace EstelApi.Core.Cqrs.Events
{
    public interface IVersionedEvent : INotification
    {
        Guid AggregateId { get; }

        long Version { get; }

        string MessageType { get;  }
    }
}