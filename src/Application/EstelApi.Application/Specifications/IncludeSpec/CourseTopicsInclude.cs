namespace EstelApi.Application.Specifications.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The course topics include.
    /// </summary>
    public class CourseTopicsInclude : BaseIncludeSpecification<CourseTopics>
    {
        public CourseTopicsInclude()
        {
            this.AddInclude(p => p.Include(x => x.Courses));
        }
    }
}