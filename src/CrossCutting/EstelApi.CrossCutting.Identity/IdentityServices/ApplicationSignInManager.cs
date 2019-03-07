namespace EstelApi.CrossCutting.Identity.IdentityServices
{
    using EstelApi.CrossCutting.Identity.IdentityModels;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    /// <inheritdoc />
    public class ApplicationSignInManager : SignInManager<ApplicationUser>
    {
        /// <inheritdoc />
        public ApplicationSignInManager(
            UserManager<ApplicationUser> userManager,
            IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor,
            ILogger<SignInManager<ApplicationUser>> logger,
            IAuthenticationSchemeProvider scheme)
            : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, scheme)
        {
        }
    }
}