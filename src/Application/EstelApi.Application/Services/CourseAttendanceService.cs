namespace EstelApi.Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    public class CourseAttendanceService : BaseService, ICourseAttendanceService
    {
        private readonly ICourseAttendanceRepository repository;

        public CourseAttendanceService(IQueryableUnitOfWork uow, ICourseAttendanceRepository repository)
            : base(uow)
        {
            this.repository = repository;
        }

        /*   public async Task<AdditionalAmenity> CreateAdditionalAmenity(CreateNewAdditionalAmenityDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var entity = processingEntity.ProjectedAs<AdditionalAmenity>();
            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }*/

        public async Task<bool> DeleteCourseAttendance(RemoveEntityCommand<CourseAttendance> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.repository.OneMatching(new FindCourseAttendanceById().SetId(processingEntity.Id));
            this.repository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }

        /*    public async Task<AdditionalAmenity> UpdateAdditionalAmenity(UpdateAdditionalAmenityDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var updateAdditionalAmenity = processingEntity.ProjectedAs<AdditionalAmenity>();
            this.repository.Modify(updateAdditionalAmenity);

            return await this.CommitAsync()
                       ? updateAdditionalAmenity
                       : throw new DatabaseException("Save exeption");
        }
        */
        public async Task<CourseAttendance> GetCourseAttendance(ISpecification<CourseAttendance> criteria = null)
        {
            var ret = this.repository.OneMatching(
                filter: criteria,
                includes: new CourseAttendanceInclude());

            return await Task.FromResult(ret);
        }

        public async Task<IEnumerable<CourseAttendance>> GetCourseAttendances(ISpecification<CourseAttendance> criteria = null)
        {
            var ret = this.repository.AllMatching(criteria, includes: new CourseAttendanceInclude());
            return await Task.FromResult(ret);
        }
    }
}