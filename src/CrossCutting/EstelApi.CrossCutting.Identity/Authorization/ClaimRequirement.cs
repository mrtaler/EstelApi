using Microsoft.AspNetCore.Authorization;

namespace EstelApi.CrossCutting.Identity.Authorization
{
    public class ClaimRequirement : IAuthorizationRequirement
    {
        public ClaimRequirement(string claimName, string claimValue)
        {
            this.ClaimName = claimName;
            this.ClaimValue = claimValue;
        }

        public string ClaimName { get; set; }
        public string ClaimValue { get; set; }
    }
}