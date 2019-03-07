namespace EstelApi.CrossCutting.Identity.Extensions
{
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using EstelApi.CrossCutting.Identity.IdentityServices.ExternalServices;

    /// <summary>
    /// The email sender extensions.
    /// </summary>
    public static class EmailSenderExtensions
    {
        /// <summary>
        /// The send email confirmation async.
        /// </summary>
        /// <param name="emailSender">
        /// The email sender.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="link">
        /// The link.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(
                email,
                "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
