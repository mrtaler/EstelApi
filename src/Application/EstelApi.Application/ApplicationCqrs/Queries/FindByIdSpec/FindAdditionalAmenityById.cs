namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindAdditionalAmenityById : FindEntitiesById<AdditionalAmenity, int>
    {
        public override Expression<Func<AdditionalAmenity, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}