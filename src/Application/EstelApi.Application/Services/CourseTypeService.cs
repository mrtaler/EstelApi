namespace EstelApi.Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Application.Specifications.FindByIdSpec;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    public class CourseTypeService : BaseService, ICourseTypeService
    {
        private readonly ICourseTypeRepository repository;

        public CourseTypeService(IQueryableUnitOfWork uow, ICourseTypeRepository repository)
            : base(uow)
        {
            this.repository = repository;
        }
        
        public async Task<CourseType> CreateCourseType(CreateNewCourseTypeDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var entity = processingEntity.ProjectedAs<CourseType>();
            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<bool> DeleteCourseType(RemoveEntity<CourseType> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.repository.OneMatching(new FindCourseTypeById().SetId(processingEntity.Id));
            this.repository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }

        public async Task<CourseType> UpdateCourseType(UpdateCourseTypeDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var updateAdditionalAmenity = processingEntity.ProjectedAs<CourseType>();
            this.repository.Modify(updateAdditionalAmenity);

            return await this.CommitAsync()
                       ? updateAdditionalAmenity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<CourseType> GetCourseType(ISpecification<CourseType> criteria = null)
        {
            var ret = this.repository.OneMatching(
                filter: criteria);

            return await Task.FromResult(ret);
        }

        public async Task<IEnumerable<CourseType>> GetCourseTypes(ISpecification<CourseType> criteria = null)
        {
            var ret = this.repository.AllMatching(criteria);
            return await Task.FromResult(ret);
        }
    }
}