namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The application role.
    /// </summary>
    public class ApplicationRole : IdentityRole<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
        /// </summary>
        public ApplicationRole()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRole"/> class.
        /// </summary>
        /// <param name="roleName">
        /// The role name.
        /// </param>
        public ApplicationRole(string roleName)
            : base(roleName)
        {
        }
    }
}
