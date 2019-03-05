using EstelApi.Core.Entities;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;
using EstelApi.Domain.DataAccessLayer.Interfaces;

namespace EstelApi.Domain.DataAccessLayer.Context.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(IQueryableUnitOfWork context) : base(context)
        {
        }
    }
}