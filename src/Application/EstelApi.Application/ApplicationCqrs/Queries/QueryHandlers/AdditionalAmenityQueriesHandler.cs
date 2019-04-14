namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;

    public class AdditionalAmenityQueriesHandler : QueryHandler,
                                        IRequestHandler<AllEntitiesQuery<AdditionalAmenity>, IEnumerable<AdditionalAmenity>>,
                                        IRequestHandler<EntityByIdQuery<AdditionalAmenity>, AdditionalAmenity>
    {
        private readonly IAdditionalAmenityRepository repository;

        public AdditionalAmenityQueriesHandler(
            IQueryableUnitOfWork uow, 
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            IAdditionalAmenityRepository additionalAmenityRepository)
            : base(uow, bus, notifications)
        {
            this.repository = additionalAmenityRepository;
        }

        public async Task<IEnumerable<AdditionalAmenity>> Handle(AllEntitiesQuery<AdditionalAmenity> request, CancellationToken cancellationToken)
        {

            var ret = this.repository.AllMatching(includes: new AdditionalAmenityInclude());
            return await Task.FromResult(ret);
        }

        public async Task<AdditionalAmenity> Handle(EntityByIdQuery<AdditionalAmenity> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.OneMatching(
                filter: new FindAdditionalAmenityById().SetId(request.Id),
                includes: new AdditionalAmenityInclude());

            return await Task.FromResult(ret);
        }
    }
}
