namespace EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices
{
    using System.Threading.Tasks;

    /// <summary>
    /// The EmailSender interface.
    /// </summary>
    public interface IEmailSender
    {
        /// <summary>
        /// The send email async.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="subject">
        /// The subject.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SendEmailAsync(string email, string subject, string message);
    }
}