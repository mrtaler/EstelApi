namespace EstelApi.Application.Specifications.FindByAllFields
{
    using System;
    using System.Linq.Expressions;

    using EstelApi.Core.Seedwork.Specifications.Specifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    public class FindAvailableDates : Specification<AvailableDates>
    {
        private readonly AvailableDates availableDates;
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