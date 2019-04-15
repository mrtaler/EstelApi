namespace EstelApi.Application.Specifications.IncludeSpec
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;

    using Microsoft.EntityFrameworkCore;

    public class CourseTypeInclude : BaseIncludeSpecification<CourseType>
    {
        public CourseTypeInclude()
        {
            this.AddInclude(p=>p.Include(y=>y.Courses));
        }
    }
}