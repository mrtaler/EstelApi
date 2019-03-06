﻿using System;
using EstelApi.Core.Seedwork.CoreCqrs.Events;

namespace EstelApi.Core.Seedwork.CoreCqrs.Notifications
{
    public class DomainNotification : VersionedEvent
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
       // public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Version = 1;
            Key = key;
            Value = value;
        }
    }
}