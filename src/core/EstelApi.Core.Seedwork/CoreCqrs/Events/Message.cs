using System;
using MediatR;

namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            this.MessageType = this.GetType().Name;
        }
    }
}
