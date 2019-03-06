using System;
using MediatR;

namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    public interface IVersionedEvent : INotification
    {
        Guid AggregateId { get; }

        long Version { get; }

        string MessageType { get;  }
    }
}