namespace EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;

    public class AvailableDatesInclude : BaseIncludeSpecification<AvailableDates>
    {
        public AvailableDatesInclude()
        {
            this.AddInclude(x => x.Include(y => y.Course));
        }
    }
}