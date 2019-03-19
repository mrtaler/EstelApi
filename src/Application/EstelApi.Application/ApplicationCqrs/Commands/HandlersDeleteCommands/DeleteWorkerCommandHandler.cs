namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class DeleteWorkerCommandHandler : CommandHandler,
                                              IRequestHandler<RemoveEntityCommand<Worker>, CommandResponse<Worker>>
    {
        private IWorkerRepository workerRepository;

        public DeleteWorkerCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            IWorkerRepository workerRepository)
            : base(uow, bus, notifications)
        {
            this.workerRepository = workerRepository;
        }

        public async Task<CommandResponse<Worker>> Handle(
            RemoveEntityCommand<Worker> request,
            CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<Worker>
                           {
                               IsSuccess = false,
                               Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                               Object = null
                           };
            }

            var current = this.workerRepository.OneMatching(new FindWorkerById().SetId(request.Id));
            this.workerRepository.Remove(current);
            return !this.Commit()
                       ? new CommandResponse<Worker> { IsSuccess = false, Message = "Delete error", Object = null }
                       : new CommandResponse<Worker>
                             {
                                 IsSuccess = true,
                                 Message = "Entity was deleted",
                                 Object = current
                             };
        }
    }
}