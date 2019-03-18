﻿namespace EstelApi.Application.ApplicationCqrs.Commands._CustomerCommands.Events
{
    using EstelApi.Core.Seedwork.CoreCqrs.Events;

    /// <summary>
    /// The customer registered event.
    /// </summary>
    public class CustomerRegisteredEvent : Event
    {
        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Telephone { get; private set; }

        public CustomerRegisteredEvent(
            int id,
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


    }
}