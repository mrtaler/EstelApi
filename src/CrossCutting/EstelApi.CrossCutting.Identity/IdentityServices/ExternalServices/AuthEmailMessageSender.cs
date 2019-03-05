using System.Threading.Tasks;

namespace EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices
{
    public class AuthEmailMessageSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }
    }
}
