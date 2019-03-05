using System.Security.Claims;
using EstelApi.CrossCutting.Identity.IdentityContext;
using EstelApi.CrossCutting.Identity.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EstelApi.CrossCutting.Identity.IdentityServices
{
    public class ApplicationRoleStore : RoleStore<
        ApplicationRole,
        IdentityEstelContext,
        int,
        ApplicationUserRole,
        ApplicationRoleClaim>
    {
        public ApplicationRoleStore(IdentityEstelContext context, IdentityErrorDescriber describer = null)
            : base(context, describer)
        {
        }

        protected override ApplicationRoleClaim CreateRoleClaim(ApplicationRole role, Claim claim)
        {
            return new ApplicationRoleClaim()
            {
                RoleId = role.Id,
                ClaimType = claim.Type,
                ClaimValue = claim.Value
            };
        }
    }
}