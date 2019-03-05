using System.Threading.Tasks;

namespace EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}