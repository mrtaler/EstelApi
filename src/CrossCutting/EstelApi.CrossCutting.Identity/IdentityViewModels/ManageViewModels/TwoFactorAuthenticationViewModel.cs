namespace EstelApi.CrossCutting.Identity.IdentityViewModels.ManageViewModels
{
    /// <summary>
    /// The two factor authentication view model.
    /// </summary>
    public class TwoFactorAuthenticationViewModel
    {
        /// <summary>
        /// Gets or sets a value indicating whether has authenticator.
        /// </summary>
        public bool HasAuthenticator { get; set; }

        /// <summary>
        /// Gets or sets the recovery codes left.
        /// </summary>
        public int RecoveryCodesLeft { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is 2 fa enabled.
        /// </summary>
        public bool Is2FaEnabled { get; set; }
    }
}