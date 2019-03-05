using Microsoft.AspNetCore.Identity;

namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ApplicationRole()
            : base()
        {
        }

        public ApplicationRole(string roleName)
            : base(roleName)
        {
        }
    }
}
