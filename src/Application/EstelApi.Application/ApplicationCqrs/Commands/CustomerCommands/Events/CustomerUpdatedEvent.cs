namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Events
{
    using System;

    using EstelApi.Core.Seedwork.CoreCqrs.Events;

    public class CustomerUpdatedEvent : Event
    {
        public CustomerUpdatedEvent(
            Guid id,
            string firstName,
            string lastName,
            string telephone)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Telephone = telephone;
            this.AggregateId = id;
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
    }
}