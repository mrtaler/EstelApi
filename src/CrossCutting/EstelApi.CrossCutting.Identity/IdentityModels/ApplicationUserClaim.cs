using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace EstelApi.CrossCutting.Identity.IdentityModels
{
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public virtual string ClaimOwner { get; set; }

        public virtual string ValueType { get; set; }

        public override Claim ToClaim()
        {
            var claim = new Claim(this.ClaimType, this.ClaimValue, this.ValueType, this.ClaimOwner);

            return claim;
        }

        /// <summary>Reads the type and value from the Claim.</summary>
        /// <param name="claim"></param>
        public override void InitializeFromClaim(Claim claim)
        {
            this.ClaimType = claim.Type;
            this.ClaimValue = claim.Value;
            this.ValueType = claim.ValueType;
            this.ClaimOwner = claim.Issuer;
        }
    }
}