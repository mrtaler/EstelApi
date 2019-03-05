using System.Threading.Tasks;

namespace EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}