using System.Collections.Generic;
using System.Security.Claims;

namespace EstelApi.Core.Seedwork.Interfaces
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}