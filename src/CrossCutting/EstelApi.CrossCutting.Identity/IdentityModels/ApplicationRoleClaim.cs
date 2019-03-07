namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The application role claim.
    /// </summary>
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
    }
}