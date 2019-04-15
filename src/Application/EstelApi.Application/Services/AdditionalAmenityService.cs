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

    public class AdditionalAmenityService : BaseService, IAdditionalAmenityService
    {
        private readonly IAdditionalAmenityRepository repository;

        public AdditionalAmenityService(IQueryableUnitOfWork uow, IAdditionalAmenityRepository repository)
            : base(uow)
        {
            this.repository = repository;
        }

        public async Task<AdditionalAmenity> CreateAdditionalAmenity(CreateNewAdditionalAmenityDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var entity = processingEntity.ProjectedAs<AdditionalAmenity>();
            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? entity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<bool> DeleteAdditionalAmenity(RemoveEntityCommand<AdditionalAmenity> processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var current = this.repository.OneMatching(new FindAdditionalAmenityById().SetId(processingEntity.Id));
            this.repository.Remove(current);
            return !await this.CommitAsync()
                       ? throw new DatabaseException("Save exeption")
                       : true;
        }

        public async Task<AdditionalAmenity> UpdateAdditionalAmenity(UpdateAdditionalAmenityDto processingEntity)
        {
            Contract.ThrowIfNull(processingEntity, processingEntity.GetType().Name);

            var updateAdditionalAmenity = processingEntity.ProjectedAs<AdditionalAmenity>();
            this.repository.Modify(updateAdditionalAmenity);

            return await this.CommitAsync()
                       ? updateAdditionalAmenity
                       : throw new DatabaseException("Save exeption");
        }

        public async Task<AdditionalAmenity> GetAdditionalAmenity(ISpecification<AdditionalAmenity> criteria = null)
        {
            var ret = this.repository.OneMatching(
                filter: criteria,
                includes: new AdditionalAmenityInclude());

            return await Task.FromResult(ret);
        }

        public async Task<IEnumerable<AdditionalAmenity>> GetAdditionalAmenities(ISpecification<AdditionalAmenity> criteria = null)
        {
            var ret = this.repository.AllMatching(criteria, includes: new AdditionalAmenityInclude());
            return await Task.FromResult(ret);
        }
    }
}