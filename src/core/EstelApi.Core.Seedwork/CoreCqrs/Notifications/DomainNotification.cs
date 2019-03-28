namespace EstelApi.Core.Seedwork.CoreCqrs.Notifications
{
    using System;

    using EstelApi.Core.Seedwork.CoreCqrs.Events;

    /// <inheritdoc />
    /// <summary>
    /// The domain notification.
    /// </summary>
    public class DomainEvent : Event
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstelApi.Core.Seedwork.CoreCqrs.Notifications.DomainNotification" /> class.
        /// </summary>
        /// <param name="key">
        /// The key.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public DomainEvent(string key, string value)
        {
            this.DomainNotificationId = Guid.NewGuid();
            this.Version = 1;
            this.Key = key;
            this.Value = value;
        }

        /// <summary>
        /// Gets the domain notification id.
        /// </summary>
        public Guid DomainNotificationId { get; private set; }

        /// <summary>
        /// Gets the key.
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        public int Version { get; private set; }
    }
}
