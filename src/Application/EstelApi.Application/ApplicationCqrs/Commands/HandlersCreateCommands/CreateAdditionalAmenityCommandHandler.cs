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

    public class CreateAdditionalAmenityCommandHandler : CommandHandler,
                                                         IRequestHandler<CreateNewAdditionalAmenityCommand, CommandResponse<AdditionalAmenity>>
    {
        private IAdditionalAmenityRepository repository;

        public CreateAdditionalAmenityCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            IAdditionalAmenityRepository additionalAmenityRepository)
            : base(uow, bus, notifications)
        {
            this.repository = additionalAmenityRepository;
        }

        public async Task<CommandResponse<AdditionalAmenity>> Handle(CreateNewAdditionalAmenityCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<AdditionalAmenity> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            this.repository.Add(request);

            return this.Commit()
                       ? new CommandResponse<AdditionalAmenity> { IsSuccess = true, Message = "New Entity was added", Object = request }
                       : new CommandResponse<AdditionalAmenity> { IsSuccess = false, Message = "New Entity Not added", Object = request };
        }
    }
}