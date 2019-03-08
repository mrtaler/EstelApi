namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    using Microsoft.AspNetCore.Identity;

    /// <inheritdoc />
    /// <summary>
    /// The application role.
    /// </summary>
    public class ApplicationRole : IdentityRole<int>
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstelApi.CrossCutting.Identity.IdentityModels.ApplicationRole" /> class.
        /// </summary>
        public ApplicationRole()
            : base()
        {
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstelApi.CrossCutting.Identity.IdentityModels.ApplicationRole" /> class.
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
