namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    public class CourseAttendanceRepository : Repository<CourseAttendance>, ICourseAttendanceRepository
    {
        public CourseAttendanceRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}