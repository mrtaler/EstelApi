﻿namespace EstelApi.CrossCutting.Bus
{
    using System;
    using System.Threading.Tasks;

    internal class BusMessageDispatcher : IBusMessageDispatcher
    {
        private readonly IQueueClient _queueClient;
        private readonly ITopicClient _topicClient;

        public BusMessageDispatcher(IQueueClient queueClient, ITopicClient topicClient)
        {
            this._queueClient = queueClient;
            this._topicClient = topicClient;
        }

        public Task DispatchAsync<TMessage>(TMessage message) where TMessage : IBusMessage
        {
            if (message is IBusQueueMessage && message is IBusTopicMessage)
                throw new NotSupportedException("The message cannot implement both the IBusQueueMessage and the IBusTopicMessage interfaces");

            if (message is IBusQueueMessage queueMessage)
                return this._queueClient.SendAsync(queueMessage);

            if (message is IBusTopicMessage topicMessage)
                return this._topicClient.SendAsync(topicMessage);

            throw new NotSupportedException("The message must implement either the IBusQueueMessage or the IBusTopicMessage interface");
        }
    }
}