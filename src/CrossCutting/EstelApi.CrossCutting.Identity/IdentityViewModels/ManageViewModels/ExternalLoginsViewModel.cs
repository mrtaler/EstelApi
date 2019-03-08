namespace EstelApi.CrossCutting.Identity.IdentityViewModels.ManageViewModels
{
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The external logins view model.
    /// </summary>
    public class ExternalLoginsViewModel
    {
        /// <summary>
        /// Gets or sets the current logins.
        /// </summary>
        public IList<UserLoginInfo> CurrentLogins { get; set; }

        /// <summary>
        /// Gets or sets the other logins.
        /// </summary>
        public IList<AuthenticationScheme> OtherLogins { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether show remove button.
        /// </summary>
        public bool ShowRemoveButton { get; set; }

        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        public string StatusMessage { get; set; }
    }
}