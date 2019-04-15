namespace EstelApi.Application.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

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

    public class AvailableDatesService : BaseService, IAvailableDatesService
    {
        private readonly IAvailableDatesRepository repository;

        public AvailableDatesService(IQueryableUnitOfWork uow, IAvailableDatesRepository repository)
            : base(uow)
        {
            this.repository = repository;
        }

        public async Task<AvailableDates> CreateAvailableDates(CreateNewAvailableDatesDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var entity = processingEntity.ProjectedAs<AvailableDates>();
            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<bool> DeleteAvailableDate(RemoveEntityCommand<AvailableDates> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.repository.OneMatching(new FindAvailableDatesById().SetId(processingEntity.Id));
            this.repository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }

        public async Task<AvailableDates> UpdateAvailableDate(UpdateAvailableDatesDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var updateAdditionalAmenity = processingEntity.ProjectedAs<AvailableDates>();
            this.repository.Modify(updateAdditionalAmenity);

            return await this.CommitAsync()
                       ? updateAdditionalAmenity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<AvailableDates> GetAvailableDate(ISpecification<AvailableDates> criteria = null)
        {
            var ret = this.repository.OneMatching(
                filter: criteria,
                includes: new AvailableDatesInclude());

            return await Task.FromResult(ret);
        }

        public async Task<IEnumerable<AvailableDates>> GetAvailableDates(ISpecification<AvailableDates> criteria = null)
        {
            var ret = this.repository.AllMatching(criteria, includes: new AvailableDatesInclude());
            return await Task.FromResult(ret);
        }
    }
}