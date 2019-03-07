namespace EstelApi.CrossCutting.Identity.Authorization
{
    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// The claim requirement.
    /// </summary>
    public class ClaimRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimRequirement"/> class.
        /// </summary>
        /// <param name="claimName">
        /// The claim name.
        /// </param>
        /// <param name="claimValue">
        /// The claim value.
        /// </param>
        public ClaimRequirement(string claimName, string claimValue)
        {
            this.ClaimName = claimName;
            this.ClaimValue = claimValue;
        }

        /// <summary>
        /// Gets or sets the claim name.
        /// </summary>
        public string ClaimName { get; set; }

        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        public string ClaimValue { get; set; }
    }
}