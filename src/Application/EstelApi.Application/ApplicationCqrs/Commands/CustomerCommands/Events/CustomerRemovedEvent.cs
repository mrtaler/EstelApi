﻿namespace EstelApi.Application.ApplicationCqrs.Commands.CustomerCommands.Events
{
    using System;

    using EstelApi.Core.Seedwork.CoreCqrs.Events;

    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(int id)
        {
            this.Id = id;
            this.AggregateId = id;
        }

        public int Id { get; set; }
    }
}