namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    using Microsoft.EntityFrameworkCore;

    public class AvailableDatesQueriesHandler : QueryHandler,
                                                IRequestHandler<AllEntitiesQuery<AvailableDates>, IEnumerable<AvailableDates>>,
                                                IRequestHandler<EntityByIdQuery<AvailableDates>, AvailableDates>
    {
        private IAvailableDatesRepository repository;

        public AvailableDatesQueriesHandler(
            IQueryableUnitOfWork uow, IMediator bus,
            INotificationHandler<DomainNotification> notifications, IAvailableDatesRepository availableDatesRepository)
            : base(uow, bus, notifications)
        {
            this.repository = availableDatesRepository;
        }

        public async Task<IEnumerable<AvailableDates>> Handle(AllEntitiesQuery<AvailableDates> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.AllMatching(includes:new AvailableDatesInclude());
            return await Task.FromResult(ret);
        }
        public async Task<AvailableDates> Handle(EntityByIdQuery<AvailableDates> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.OneMatching(
                filter: new FindAvailableDatesById().SetId(request.Id),
                includes: new AvailableDatesInclude());
            return await Task.FromResult(ret);
        }
    }
}