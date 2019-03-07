using System;
using MediatR;

namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}