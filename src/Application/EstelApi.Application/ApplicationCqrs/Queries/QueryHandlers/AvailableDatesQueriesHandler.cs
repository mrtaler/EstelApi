namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

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
            this.repository.SetInclude(new List<Func<IQueryable<AvailableDates>, IQueryable<AvailableDates>>>
                                           {
                                               x => x.Include(y => y.Course)
                                           });
        }

        public async Task<IEnumerable<AvailableDates>> Handle(AllEntitiesQuery<AvailableDates> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.GetAll();
            return await Task.FromResult(ret);
        }
        public async Task<AvailableDates> Handle(EntityByIdQuery<AvailableDates> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.Get(request.Id);
            return await Task.FromResult(ret);
        }
    }
}