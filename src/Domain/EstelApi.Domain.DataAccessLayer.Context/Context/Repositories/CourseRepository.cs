namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}