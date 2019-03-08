namespace EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices
{
    using System.Threading.Tasks;

    /// <inheritdoc />
    public class AuthEmailMessageSender : IEmailSender
    {
        /// <inheritdoc />
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }
}
