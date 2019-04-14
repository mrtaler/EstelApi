//namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
//{
//    using System.Collections.Generic;
//    using System.Threading;
//    using System.Threading.Tasks;

//    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
//    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
//    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

//    using MediatR;

//    public class AvailableDatesQueriesHandler : QueryHandler,
//                                                IRequestHandler<AllEntitiesQuery<AvailableDates>, IEnumerable<AvailableDates>>,
//                                                IRequestHandler<EntityByIdQuery<AvailableDates>, AvailableDates>
//    {
//        private IAvailableDatesRepository repository;

//        public AvailableDatesQueriesHandler(
//            IQueryableUnitOfWork uow, IMediator bus,
//            INotificationHandler<DomainEvent> notifications, IAvailableDatesRepository availableDatesRepository)
//            : base(uow, bus, notifications)
//        {
//            this.repository = availableDatesRepository;
//        }

//        public async Task<IEnumerable<AvailableDates>> Handle(AllEntitiesQuery<AvailableDates> request, CancellationToken cancellationToken)
//        {
//            var ret = this.repository.AllMatching(includes:new AvailableDatesInclude());
//            return await Task.FromResult(ret);
//        }
//        public async Task<AvailableDates> Handle(EntityByIdQuery<AvailableDates> request, CancellationToken cancellationToken)
//        {
//            var ret = this.repository.OneMatching(
//                filter: new FindAvailableDatesById().SetId(request.Id),
//                includes: new AvailableDatesInclude());
//            return await Task.FromResult(ret);
//        }
//    }
//}