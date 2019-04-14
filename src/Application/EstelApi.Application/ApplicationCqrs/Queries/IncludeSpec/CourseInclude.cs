namespace EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;

    public class CourseInclude : BaseIncludeSpecification<Course>
    {
        public CourseInclude()
        {
            this.AddInclude(x => x
                .Include(p => p.CourseType));
            this.AddInclude(x => x.Include(p => p.CourseAttendances));
            this.AddInclude(x => x.Include(p => p.CourseAttendances)
                .ThenInclude(p => p.User));
            this.AddInclude(x => x.Include(p => p.CourseTopics));
            this.AddInclude(x => x.Include(p => p.CourseTopics)
                .ThenInclude(p => p.CourseTopics));
            this.AddInclude(x => x.Include(p => p.AdditionalAmenityCourses));
            this.AddInclude(x => x.Include(p => p.AdditionalAmenityCourses)
                .ThenInclude(p => p.AdditionalAmenity));
            this.AddInclude(x => x
                .Include(p => p.AvailableDates));
            this.AddInclude(x => x
                .Include(p => p.AvailableDates)
                .ThenInclude(z => z.AvailableDates));
        }
    }
}