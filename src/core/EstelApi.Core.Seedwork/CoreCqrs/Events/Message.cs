namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    using System;

    using MediatR;

    /// <summary>
    /// The message.
    /// </summary>
    public abstract class Message : IRequest<bool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        protected Message()
        {
            this.MessageType = this.GetType().Name;
        }

        /// <summary>
        /// Gets or sets the message type.
        /// </summary>
        public string MessageType { get; protected set; }

        /// <summary>
        /// Gets or sets the aggregate id.
        /// </summary>
        public int AggregateId { get; protected set; }
    }
}
