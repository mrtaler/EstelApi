using System;
using EstelApi.Core.Seedwork.CoreCqrs.Events;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Events
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(Guid id)
        {
            this.Id = id;
            this.AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}