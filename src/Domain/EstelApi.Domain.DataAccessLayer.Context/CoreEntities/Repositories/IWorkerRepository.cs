namespace EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg
{
    using EstelApi.Core.Seedwork.Interfaces;

    public interface IWorkerRepository : IRepository<Worker>{}
    public interface IAdditionalAmenityRepository : IRepository<AdditionalAmenity>{}
    public interface IAvailableDatesRepository : IRepository<AvailableDates>{}
    public interface ICourseRepository : IRepository<Course>{}
    public interface ICourseAttendanceRepository : IRepository<CourseAttendance>{}
    public interface ICourseTopicsRepository : IRepository<CourseTopics>{}
    public interface ICourseTypeRepository : IRepository<CourseType>{}
}