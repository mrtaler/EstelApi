namespace EstelApi.Application.Specifications.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;

    public class CourseAttendanceInclude : BaseIncludeSpecification<CourseAttendance>
    {
        public CourseAttendanceInclude()
        {
            this.AddInclude(x => x.Include(p => p.User));
            this.AddInclude(x => x.Include(p => p.Course));
        }
    }
}