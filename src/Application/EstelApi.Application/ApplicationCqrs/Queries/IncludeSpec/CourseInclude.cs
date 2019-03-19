namespace EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;

    public class CourseInclude : BaseIncludeSpecification<Course>
    {
        public CourseInclude()
        {
            this.AddInclude(x => x.Include(p => p.CourseType));
            this.AddInclude(x => x.Include(p => p.CourseAttendances));
            this.AddInclude(x => x.Include(p => p.CourseTopics));
            this.AddInclude(x => x.Include(p => p.AdditionalAmenityCourses));
            this.AddInclude(x => x.Include(p => p.AvailableDates));
        }
    }
}