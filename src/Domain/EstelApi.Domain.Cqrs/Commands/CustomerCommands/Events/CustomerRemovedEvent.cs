using System;
using EstelApi.Core.Seedwork.CoreCqrs.Events;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Events
{
    public class CustomerRemovedEvent : VersionedEvent
    {
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}