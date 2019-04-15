namespace EstelApi.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Specifications.FindByIdSpec;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    public class CourseAttendanceService : BaseService, ICourseAttendanceService
    {
        private readonly ICourseAttendanceRepository repository;
        private readonly IUserRepository userRepository;

        public CourseAttendanceService(
            IQueryableUnitOfWork uow,
            ICourseAttendanceRepository repository,
            IUserRepository userRepository)
            : base(uow)
        {
            this.repository = repository;
            this.userRepository = userRepository;
        }

        public async Task<bool> DeleteCourseAttendance(RemoveEntity<CourseAttendance> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.repository.OneMatching(new FindCourseAttendanceById().SetId(processingEntity.Id));
            this.repository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }

        public async Task<CourseAttendance> GetCourseAttendance(ISpecification<CourseAttendance> criteria = null)
        {
            var ret = this.repository.OneMatching(filter: criteria);

            return await Task.FromResult(ret);
        }

        public async Task<IEnumerable<CourseAttendance>> GetCourseAttendances(ISpecification<CourseAttendance> criteria = null)
        {
            var ret = this.repository.AllMatching(criteria);
            return await Task.FromResult(ret);
        }

        // todo check for test
        public async Task<CourseAttendance> UserAttendToCourse(int userId, int courseId)
        {

            var entity = new CourseAttendance()
            {
                CourseId = courseId,
                CustomerId = userId,
                AttendenseDate = DateTimeOffset.UtcNow,
                Status = CourseAttendenseStatus.Attendent
            };

            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }
    }
}