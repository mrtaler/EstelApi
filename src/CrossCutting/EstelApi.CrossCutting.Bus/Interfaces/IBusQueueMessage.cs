﻿namespace EstelApi.CrossCutting.Bus
{
    public interface IBusQueueMessage : IBusMessage
    {
        string QueueName { get; set; }
    }
}