namespace EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices
{
    using System.Threading.Tasks;

    /// <summary>
    /// The SmsSender interface.
    /// </summary>
    public interface ISmsSender
    {
        /// <summary>
        /// The send sms async.
        /// </summary>
        /// <param name="number">
        /// The number.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SendSmsAsync(string number, string message);
    }
}