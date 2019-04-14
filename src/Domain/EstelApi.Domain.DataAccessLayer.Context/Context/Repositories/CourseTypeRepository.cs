namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    public class CourseTypeRepository : Repository<CourseType>, ICourseTypeRepository
    {
        public CourseTypeRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}