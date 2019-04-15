namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;

    public class CourseTopicsRepository : Repository<CourseTopics>, ICourseTopicsRepository
    {
        public CourseTopicsRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}