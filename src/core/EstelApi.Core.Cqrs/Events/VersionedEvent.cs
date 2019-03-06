using System;

namespace EstelApi.Core.Cqrs.Events
{
    public abstract class VersionedEvent : IVersionedEvent
    {
        public DateTime Timestamp { get; protected set; }

        public Guid AggregateId { get; set; }

        public long Version { get; set; }

        public string MessageType { get; protected set; }

        protected VersionedEvent()
        {
            Timestamp = DateTime.Now;
            MessageType = GetType().Name;
        }
    }
}