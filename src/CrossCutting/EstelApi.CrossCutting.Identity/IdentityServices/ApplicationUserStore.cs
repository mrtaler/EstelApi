using System.Security.Claims;
using EstelApi.CrossCutting.Identity.IdentityContext;
using EstelApi.CrossCutting.Identity.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EstelApi.CrossCutting.Identity.IdentityServices
{
    public class ApplicationUserStore : UserStore<
        ApplicationUser,
        ApplicationRole,
        IdentityEstelContext,
        int,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationUserToken,
        ApplicationRoleClaim>
    {
        public ApplicationUserStore(IdentityEstelContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override ApplicationUserRole CreateUserRole(ApplicationUser user, ApplicationRole role)
        {
            return new ApplicationUserRole()
            {
                UserId = user.Id,
                RoleId = role.Id
            };
        }

        protected override ApplicationUserClaim CreateUserClaim(ApplicationUser user, Claim claim)
        {
            var userClaim = new ApplicationUserClaim() { UserId = user.Id };
            userClaim.InitializeFromClaim(claim);
            return userClaim;
        }

        protected override ApplicationUserLogin CreateUserLogin(ApplicationUser user, UserLoginInfo login)
        {
            return new ApplicationUserLogin()
            {
                UserId = user.Id,
                ProviderKey = login.ProviderKey,
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName
            };
        }

        protected override ApplicationUserToken CreateUserToken(ApplicationUser user, string loginProvider, string name, string value)
        {
            return new ApplicationUserToken()
            {
                UserId = user.Id,
                LoginProvider = loginProvider,
                Name = name,
                Value = value
            };
        }
    }
}