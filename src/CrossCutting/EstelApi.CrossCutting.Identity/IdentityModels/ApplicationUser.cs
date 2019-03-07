namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    /// The application user.
    /// </summary>
    public class ApplicationUser : IdentityUser<int>
    {
    }
}