namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    public class UpdateAvailableDatesCommandHandler : CommandHandler,
                                        IRequestHandler<UpdateAvailableDatesCommand, CommandResponse<AvailableDates>>
    {
        private readonly IAvailableDatesRepository repository;

        public UpdateAvailableDatesCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            IAvailableDatesRepository availableDatesRepository)
            : base(uow, bus, notifications)
        {
            this.repository = availableDatesRepository;
        }

        public async Task<CommandResponse<AvailableDates>> Handle(UpdateAvailableDatesCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<AvailableDates> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            var updateAvailableDates = request.ProjectedAs<AvailableDates>();
            this.repository.Modify(updateAvailableDates);

            return await this.Commit()
                       ? new CommandResponse<AvailableDates> { IsSuccess = true, Message = "New Entity was added", Object = updateAvailableDates }
                       : new CommandResponse<AvailableDates> { IsSuccess = false, Message = "New Entity Not added", Object = updateAvailableDates };
        }
    }
}
