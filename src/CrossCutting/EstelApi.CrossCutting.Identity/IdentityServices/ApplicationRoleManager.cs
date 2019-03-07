namespace EstelApi.CrossCutting.Identity.IdentityServices
{
    using System.Collections.Generic;

    using EstelApi.CrossCutting.Identity.IdentityModels;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;

    /// <inheritdoc />
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        /// <inheritdoc />
        public ApplicationRoleManager(
            IRoleStore<ApplicationRole> store,
            IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleManager<ApplicationRole>> logger)
            : base(store, roleValidators, keyNormalizer, errors, logger)
        {
        }
    }
}
