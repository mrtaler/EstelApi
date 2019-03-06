using EstelApi.Core.Seedwork.CoreEntities;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

namespace EstelApi.Domain.DataAccessLayer.Context.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(IQueryableUnitOfWork context) : base(context)
        {
        }
    }
}