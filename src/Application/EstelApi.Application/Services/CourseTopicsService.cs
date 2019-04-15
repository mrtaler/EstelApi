namespace EstelApi.Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
    using EstelApi.Application.Dto;
    using EstelApi.Application.Interfaces;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.Specifications.Interfaces;
    using EstelApi.Domain.DataAccessLayer.Context.Context.Base;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    public class CourseTopicsService : BaseService, ICourseTopicsService
    {
        private readonly ICourseTopicsRepository repository;

        public CourseTopicsService(IQueryableUnitOfWork uow, ICourseTopicsRepository repository)
            : base(uow)
        {
            this.repository = repository;
        }

        public async Task<CourseTopics> CreateCourseTopics(CreateNewCourseTopicsDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var entity = processingEntity.ProjectedAs<CourseTopics>();
            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<bool> DeleteCourseTopics(RemoveEntityCommand<CourseTopics> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.repository.OneMatching(new FindCourseTopicsById().SetId(processingEntity.Id));
            this.repository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }

        public async Task<CourseTopics> UpdateCourseTopics(UpdateCourseTopicsDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var updateAdditionalAmenity = processingEntity.ProjectedAs<CourseTopics>();
            this.repository.Modify(updateAdditionalAmenity);

            return await this.CommitAsync()
                       ? updateAdditionalAmenity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<CourseTopics> GetCourseTopic(ISpecification<CourseTopics> criteria = null)
        {
            var ret = this.repository.OneMatching(
                filter: criteria,
                includes: new CourseTopicsInclude());

            return await Task.FromResult(ret);
        }

        public async Task<IEnumerable<CourseTopics>> GetCourseTopics(ISpecification<CourseTopics> criteria = null)
        {
            var ret = this.repository.AllMatching(criteria, includes: new CourseTopicsInclude());
            return await Task.FromResult(ret);
        }
    }
}