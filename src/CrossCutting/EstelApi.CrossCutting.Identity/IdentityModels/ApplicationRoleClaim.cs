namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    using Microsoft.AspNetCore.Identity;

    /// <inheritdoc />
    /// <summary>
    /// The application role claim.
    /// </summary>
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
    }
}