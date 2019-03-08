namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    /// <summary>
    /// The EventStore interface.
    /// </summary>
    public interface IEventStore
    {
        /// <summary>
        /// The save.
        /// </summary>
        /// <param name="theEvent">
        /// The the event.
        /// </param>
        /// <typeparam name="T">Is any Event
        /// </typeparam>
        void Save<T>(T theEvent) where T : Event;
    }
}
