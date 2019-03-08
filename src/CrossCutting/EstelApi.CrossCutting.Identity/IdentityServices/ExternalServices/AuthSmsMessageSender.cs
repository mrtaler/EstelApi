namespace EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices
{
    using System.Threading.Tasks;

    /// <inheritdoc />
    public class AuthSmsMessageSender : ISmsSender
    {
        /// <inheritdoc />
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
        /// The <see cref="T:System.Threading.Tasks.Task" />.
        /// </returns>
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}