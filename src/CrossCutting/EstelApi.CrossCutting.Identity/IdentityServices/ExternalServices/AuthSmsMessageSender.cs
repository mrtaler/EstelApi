using System.Threading.Tasks;

namespace EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices
{
    public class AuthSmsMessageSender : ISmsSender
    {
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}