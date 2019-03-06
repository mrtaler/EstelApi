using System;
using EstelApi.Core.Seedwork.CoreCqrs.Events;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Events
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