namespace EstelApi.Core.Seedwork.CoreCqrs.Events
{
    /// <summary>
    /// The Handler interface.
    /// </summary>
    /// <typeparam name="T">don't know
    /// </typeparam>
    public interface IHandler<in T> where T : Message
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        void Handle(T message);
    }
}