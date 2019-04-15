namespace EstelApi.Application.Specifications.FindByAllFields
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Core.Seedwork.Specifications.Specifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindAdditionalAmenity : Specification<AdditionalAmenity>
    {
        private readonly AdditionalAmenity additionalAmenity;
        public FindAdditionalAmenity(AdditionalAmenity availableDates)
        {
            this.additionalAmenity = availableDates;
        }

        public override Expression<Func<AdditionalAmenity, bool>> AsExpression()
        {
            return p =>
                p.AdditionalAmenityName == this.additionalAmenity.AdditionalAmenityName;
        }
    }
}