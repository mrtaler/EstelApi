﻿using System;
using EstelApi.Core.Cqrs.Events;

namespace EstelApi.Domain.Cqrs.Commands.CustomerCommands.Events
{
    public class CustomerRegisteredEvent : VersionedEvent
    {
        public CustomerRegisteredEvent(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            AggregateId = id;
        }
        public Guid Id { get; set; }

        public string Name { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}