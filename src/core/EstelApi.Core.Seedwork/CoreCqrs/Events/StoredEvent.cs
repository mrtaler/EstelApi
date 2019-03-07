using System;

namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    public class StoredEvent : Event
    {
        public StoredEvent(Event theEvent, string data, string user)
        {
            this.Id = Guid.NewGuid();
            this.AggregateId = theEvent.AggregateId;
            this.MessageType = theEvent.MessageType;
            this.Data = data;
            this.User = user;
        }

        // EF Constructor
        protected StoredEvent() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}