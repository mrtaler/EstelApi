namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    using System.Collections.Generic;
    using System.Security.Claims;

    using EstelApi.Core.Seedwork.Interfaces;

    using Microsoft.AspNetCore.Http;

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

        /// <summary>
        /// The name.
        /// </summary>
        public string Name => this.accessor.HttpContext.User.Identity.Name;

        /// <summary>
        /// The is authenticated.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsAuthenticated()
        {
            return this.accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return this.accessor.HttpContext.User.Claims;
        }


    }
}