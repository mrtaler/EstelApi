﻿namespace EstelApi.Core.Cqrs.Events
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}