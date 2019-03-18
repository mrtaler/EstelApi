namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

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
            var ret = this.repository.GetAll();
            return await Task.FromResult(ret);
        }
        public async Task<Worker> Handle(EntityByIdQuery<Worker> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.Get(request.Id);
            return await Task.FromResult(ret);
        }
    }
}