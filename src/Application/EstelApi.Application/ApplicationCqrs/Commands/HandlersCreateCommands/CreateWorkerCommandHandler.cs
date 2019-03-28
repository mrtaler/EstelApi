namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.CrossCutting.Bus;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    public class CreateWorkerCommandHandler : CommandHandler,
                                              IRequestHandler<CreateNewWorkerCommand, CommandResponse<Worker>>
    {
        private readonly IWorkerRepository repository;

        public CreateWorkerCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            IWorkerRepository workerRepository)
            : base(uow, bus, notifications)
        {
            this.repository = workerRepository;
        }

        public async Task<CommandResponse<Worker>> Handle(CreateNewWorkerCommand request, CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var entity = request.ProjectedAs<Worker>();
            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? new CommandResponse<Worker> { IsSuccess = true, Message = "New Entity was added", Object = entity }
                       : new CommandResponse<Worker> { IsSuccess = false, Message = "New Entity Not added", Object = entity };
        }
    }
}