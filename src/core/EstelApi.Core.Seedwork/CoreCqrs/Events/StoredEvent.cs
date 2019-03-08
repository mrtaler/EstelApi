namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    using System;

    /// <inheritdoc />
    /// <summary>
    /// The stored event.
    /// </summary>
    public class StoredEvent : Event
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstelApi.Core.Seedwork.CoreCqrs.Events.StoredEvent" /> class.
        /// </summary>
        /// <param name="theEvent">
        /// The the event.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <param name="user">
        /// The user.
        /// </param>
        public StoredEvent(Event theEvent, string data, string user)
        {
            this.Id = Guid.NewGuid();
            this.AggregateId = theEvent.AggregateId;
            this.MessageType = theEvent.MessageType;
            this.Data = data;
            this.User = user;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstelApi.Core.Seedwork.CoreCqrs.Events.StoredEvent" /> class. For EF 
        /// </summary>
        protected StoredEvent()
        {
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// Gets the user.
        /// </summary>
        public string User { get; private set; }
    }
}