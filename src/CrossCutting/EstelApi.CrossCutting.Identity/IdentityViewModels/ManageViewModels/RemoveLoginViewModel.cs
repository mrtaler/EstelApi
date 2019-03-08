namespace EstelApi.CrossCutting.Identity.IdentityViewModels.ManageViewModels
{
    /// <summary>
    /// The remove login view model.
    /// </summary>
    public class RemoveLoginViewModel
    {
        /// <summary>
        /// Gets or sets the login provider.
        /// </summary>
        public string LoginProvider { get; set; }

        /// <summary>
        /// Gets or sets the provider key.
        /// </summary>
        public string ProviderKey { get; set; }
    }
}