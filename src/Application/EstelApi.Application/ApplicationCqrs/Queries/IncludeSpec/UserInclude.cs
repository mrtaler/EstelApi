namespace EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using Microsoft.EntityFrameworkCore;

    public class UserInclude : BaseIncludeSpecification<User>
    {
        public UserInclude()
        {
            this.AddInclude(p => p.Include(x => x.CourseAttendances));
            this.AddInclude(p => p.Include(x => x.CourseAttendances).ThenInclude(y => y.Course));
        }
    }
}