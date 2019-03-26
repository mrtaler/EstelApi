namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateWorkerCommandHandler : CommandHandler,
                                              IRequestHandler<UpdateWorkerCommand, CommandResponse<Worker>>
    {
        private readonly IWorkerRepository repository;

        public UpdateWorkerCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            IWorkerRepository workerRepository)
            : base(uow, bus, notifications)
        {
            this.repository = workerRepository;
        }

        public async Task<CommandResponse<Worker>> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<Worker> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            var updateWorker = request.ProjectedAs<Worker>();
            this.repository.Modify(updateWorker);
            return this.Commit()
                       ? new CommandResponse<Worker> { IsSuccess = true, Message = "New Entity was added", Object = updateWorker }
                       : new CommandResponse<Worker> { IsSuccess = false, Message = "New Entity Not added", Object = updateWorker };
        }
    }
}