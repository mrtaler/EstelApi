using System;
using EstelApi.Core.Cqrs.Events;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Events
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}