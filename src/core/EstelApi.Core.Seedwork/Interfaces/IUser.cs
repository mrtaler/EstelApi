namespace EstelApi.Core.Seedwork.Interfaces
{
    using System.Collections.Generic;
    using System.Security.Claims;

    /// <summary>
    /// The User interface.
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// Gets the name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The is authenticated.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool IsAuthenticated();

        /// <summary>
        /// The get claims identity.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<Claim> GetClaimsIdentity();
    }
}