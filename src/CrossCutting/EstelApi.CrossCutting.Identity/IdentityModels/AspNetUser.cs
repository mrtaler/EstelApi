namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using EstelApi.Core.Seedwork.Interfaces;

    using Microsoft.AspNetCore.Http;

    /// <inheritdoc />
    /// <summary>
    /// The asp net user.
    /// </summary>
    public class AspNetUser : IUser
    {
        /// <summary>
        /// The accessor.
        /// </summary>
        private readonly IHttpContextAccessor accessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AspNetUser"/> class.
        /// </summary>
        /// <param name="accessor">
        /// The accessor.
        /// </param>
        public AspNetUser(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        /// <inheritdoc />
        /// <summary>
        /// The name.
        /// </summary>
        public string Name => this.accessor.HttpContext.User.Identity.Name;

        /// <inheritdoc />
        /// <summary>
        /// The is authenticated.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Boolean" />.
        /// </returns>
        public bool IsAuthenticated()
        {
            return this.accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        /// <inheritdoc />
        /// <summary>
        /// The get claims identity.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IEnumerable`1" />.
        /// </returns>
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return this.accessor.HttpContext.User.Claims;
        }
    }
}