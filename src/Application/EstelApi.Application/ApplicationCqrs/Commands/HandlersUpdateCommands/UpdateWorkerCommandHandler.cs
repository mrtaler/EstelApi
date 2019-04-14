namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    public class UpdateWorkerCommandHandler : CommandHandler,
                                              IRequestHandler<UpdateWorkerCommand, CommandResponse<Worker>>
    {
        private readonly IWorkerRepository repository;

        public UpdateWorkerCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            IWorkerRepository workerRepository)
            : base(uow, bus, notifications)
        {
            this.repository = workerRepository;
        }

        public async Task<CommandResponse<Worker>> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var updateWorker = request.ProjectedAs<Worker>();
            this.repository.Modify(updateWorker);
            return await this.CommitAsync()
                       ? new CommandResponse<Worker> { IsSuccess = true, Message = "New Entity was added", Object = updateWorker }
                       : new CommandResponse<Worker> { IsSuccess = false, Message = "New Entity Not added", Object = updateWorker };
        }
    }
}