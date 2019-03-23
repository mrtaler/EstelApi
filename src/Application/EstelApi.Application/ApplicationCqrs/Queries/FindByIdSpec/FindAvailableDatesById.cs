namespace EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec
{
    using EstelApi.Core.Seedwork.Specifications.Specifications;
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

    public class FindAvailableDates : Specification<AvailableDates>
    {
        private AvailableDates availableDates;
        public FindAvailableDates(AvailableDates availableDates)
        {
            this.availableDates = availableDates;
        }

        public override Expression<Func<AvailableDates, bool>> AsExpression()
        {
            return p =>
                p.Date == this.availableDates.Date &&
                p.EndHour == this.availableDates.EndHour &&
                p.StartHour == this.availableDates.StartHour &&
                p.Month == this.availableDates.Month;
        }
    }
}