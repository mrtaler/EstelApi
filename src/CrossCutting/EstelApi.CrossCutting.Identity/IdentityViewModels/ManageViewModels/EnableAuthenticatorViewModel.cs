namespace EstelApi.CrossCutting.Identity.IdentityViewModels.ManageViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// The enable authenticator view model.
    /// </summary>
    public class EnableAuthenticatorViewModel
    {
        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Verification Code")]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets the shared key.
        /// </summary>
        [ReadOnly(true)]
        public string SharedKey { get; set; }

        /// <summary>
        /// Gets or sets the authenticator uri.
        /// </summary>
        public string AuthenticatorUri { get; set; }
    }
}