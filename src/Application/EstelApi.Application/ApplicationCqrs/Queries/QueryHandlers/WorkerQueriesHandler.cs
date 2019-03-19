namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;

    public class WorkerQueriesHandler : QueryHandler,
                                        IRequestHandler<AllEntitiesQuery<Worker>, IEnumerable<Worker>>,
                                        IRequestHandler<EntityByIdQuery<Worker>, Worker>
    {
        private IWorkerRepository repository;
        public WorkerQueriesHandler(IQueryableUnitOfWork uow, IMediator bus, INotificationHandler<DomainNotification> notifications, IWorkerRepository workerRepository)
            : base(uow, bus, notifications)
        {
            this.repository = workerRepository;
        }

        public async Task<IEnumerable<Worker>> Handle(AllEntitiesQuery<Worker> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.AllMatching(includes: new WorkerInclude());
            return await Task.FromResult(ret);
        }
        public async Task<Worker> Handle(EntityByIdQuery<Worker> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.OneMatching(
                filter: new FindWorkerById().SetId(request.Id),
                includes: new WorkerInclude());

            return await Task.FromResult(ret);
        }
    }
}