using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

namespace EstelApi.Domain.DataAccessLayer.Context.Repository
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(IQueryableUnitOfWork context) : base(context)
        {
        }
    }
}