namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindAvailableDatesById : FindEntitiesById<AvailableDates, int>
    {
        public override Expression<Func<AvailableDates, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}