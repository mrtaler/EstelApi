namespace EstelApi.CrossCutting.Identity.Authorization
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;

    /// <summary>
    /// The claims requirement handler.
    /// </summary>
    public class ClaimsRequirementHandler : AuthorizationHandler<ClaimRequirement>
    {
        /// <summary>
        /// The handle requirement async.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="requirement">
        /// The requirement.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            ClaimRequirement requirement)
        {
            var claim = context.User.Claims.FirstOrDefault(c => c.Type == requirement.ClaimName);
            if (claim != null && claim.Value.Contains(requirement.ClaimValue))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}