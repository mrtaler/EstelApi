namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using System;
    using System.Linq.Expressions;

    public class FindAvailableDatesById : FindEntitiesById<AvailableDates, int>
    {
        public override Expression<Func<AvailableDates, bool>> AsExpression()
        {
            return p => p.Id == this.Id;
        }
    }
}