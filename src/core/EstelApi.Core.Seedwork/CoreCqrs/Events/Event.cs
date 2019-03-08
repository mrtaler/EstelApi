namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    using System;

    using MediatR;

    /// <summary>
    /// The event.
    /// </summary>
    public abstract class Event : Message, INotification
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        protected Event()
        {
            this.Timestamp = DateTime.Now;
        }

        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        public DateTime Timestamp { get; private set; }
    }
}