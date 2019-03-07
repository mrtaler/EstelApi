using System;
using EstelApi.Core.Seedwork.CoreCqrs.Events;

namespace EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Events
{
    public class CustomerUpdatedEvent : Event
    {
        public CustomerUpdatedEvent(Guid id, string name, string email, DateTime birthDate)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.BirthDate = birthDate;
            this.AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}