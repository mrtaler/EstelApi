namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Identity;

    /// <inheritdoc />
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        /// <summary>
        /// Gets or sets the claim owner.
        /// </summary>
        public virtual string ClaimOwner { get; set; }

        /// <summary>
        /// Gets or sets the value type.
        /// </summary>
        public virtual string ValueType { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// The to claim.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Security.Claims.Claim" />.
        /// </returns>
        public override Claim ToClaim()
        {
            var claim = new Claim(this.ClaimType, this.ClaimValue, this.ValueType, this.ClaimOwner);

            return claim;
        }

        /// <inheritdoc />
        public override void InitializeFromClaim(Claim claim)
        {
            this.ClaimType = claim.Type;
            this.ClaimValue = claim.Value;
            this.ValueType = claim.ValueType;
            this.ClaimOwner = claim.Issuer;
        }
    }
}