namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    using Microsoft.EntityFrameworkCore;
    // using EstelApi.Application.Dto;

    public class AdditionalAmenityQueriesHandler : QueryHandler,
                                        IRequestHandler<AllEntitiesQuery<AdditionalAmenity>, IEnumerable<AdditionalAmenity>>,
                                        IRequestHandler<EntityByIdQuery<AdditionalAmenity>, AdditionalAmenity>
    {
        private IAdditionalAmenityRepository repository;

        public AdditionalAmenityQueriesHandler(
            IQueryableUnitOfWork uow, IMediator bus,
            INotificationHandler<DomainNotification> notifications, IAdditionalAmenityRepository additionalAmenityRepository)
            : base(uow, bus, notifications)
        {
            this.repository = additionalAmenityRepository;
            this.repository.SetInclude(new List<Func<IQueryable<AdditionalAmenity>, IQueryable<AdditionalAmenity>>>
                                           {
                                               p => p.Include(x =>x.AdditionalAmenityCourses),
                                           });
        }

        public async Task<IEnumerable<AdditionalAmenity>> Handle(AllEntitiesQuery<AdditionalAmenity> request, CancellationToken cancellationToken)
        {

            var ret = this.repository.GetAll();
            return await Task.FromResult(ret);
        }

        public async Task<AdditionalAmenity> Handle(EntityByIdQuery<AdditionalAmenity> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.Get(request.Id);
            return await Task.FromResult(ret);
        }
    }
}
