using System.Collections.Generic;
using System.Security.Claims;
using EstelApi.Core.Seedwork.Interfaces;
using Microsoft.AspNetCore.Http;

namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    public class AspNetUser : IUser
    {
        private readonly IHttpContextAccessor accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public string Name => this.accessor.HttpContext.User.Identity.Name;

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