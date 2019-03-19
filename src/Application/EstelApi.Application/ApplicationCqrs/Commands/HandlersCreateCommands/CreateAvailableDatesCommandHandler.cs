namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class CreateAvailableDatesCommandHandler : CommandHandler,
                                        IRequestHandler<CreateNewAvailableDatesCommand, CommandResponse<AvailableDates>>
    {
        private IAvailableDatesRepository repository;

        public CreateAvailableDatesCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            IAvailableDatesRepository availableDatesRepository)
            : base(uow, bus, notifications)
        {
            this.repository = availableDatesRepository;
        }

        public async Task<CommandResponse<AvailableDates>> Handle(CreateNewAvailableDatesCommand request, CancellationToken cancellationToken)
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

            this.repository.Add(request);

            return this.Commit()
                       ? new CommandResponse<AvailableDates> { IsSuccess = true, Message = "New Entity was added", Object = request }
                       : new CommandResponse<AvailableDates> { IsSuccess = false, Message = "New Entity Not added", Object = request };
        }
    }
}
