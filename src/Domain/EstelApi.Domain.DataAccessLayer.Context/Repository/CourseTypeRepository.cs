using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

namespace EstelApi.Domain.DataAccessLayer.Context.Repository
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;

    public class CourseTypeRepository : Repository<CourseType>, ICourseTypeRepository
    {
        public CourseTypeRepository(IQueryableUnitOfWork context) : base(context)
        {
        }
    }
}