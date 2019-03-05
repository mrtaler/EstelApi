using EstelApi.Core.Entities;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;
using EstelApi.Domain.DataAccessLayer.Interfaces;

namespace EstelApi.Domain.DataAccessLayer.Context.Repository
{
    public class CourseTypeRepository : Repository<CourseType>, ICourseTypeRepository
    {
        public CourseTypeRepository(IQueryableUnitOfWork context) : base(context)
        {
        }
    }
}