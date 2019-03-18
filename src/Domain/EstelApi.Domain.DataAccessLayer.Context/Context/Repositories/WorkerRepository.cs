namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    public class WorkerRepository : Repository<Worker>,IWorkerRepository
    {
        public WorkerRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
    public class AdditionalAmenityRepository : Repository<AdditionalAmenity>, IAdditionalAmenityRepository {
        public AdditionalAmenityRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
    public class AvailableDatesRepository : Repository<AvailableDates> , IAvailableDatesRepository {
        public AvailableDatesRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
    public class CourseRepository : Repository<Course> , ICourseRepository {
        public CourseRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
    public class CourseAttendanceRepository : Repository<CourseAttendance> , ICourseAttendanceRepository {
        public CourseAttendanceRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
    public class CourseTopicsRepository : Repository<CourseTopics> , ICourseTopicsRepository {
        public CourseTopicsRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
    public class CourseTypeRepository : Repository<CourseType> , ICourseTypeRepository {
        public CourseTypeRepository(EstelContext unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}