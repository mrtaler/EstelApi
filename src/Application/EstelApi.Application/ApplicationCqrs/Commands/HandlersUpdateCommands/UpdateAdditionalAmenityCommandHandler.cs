namespace EstelApi.Application.ApplicationCqrs.Commands.DeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.CreateCommands;
    using EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class UpdateAdditionalAmenityCommandHandler : CommandHandler,
                                                         IRequestHandler<UpdateAdditionalAmenityCommand, CommandResponse<AdditionalAmenity>>
    {
        private IAdditionalAmenityRepository repository;

        public UpdateAdditionalAmenityCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            IAdditionalAmenityRepository additionalAmenityRepository)
            : base(uow, bus, notifications)
        {
            this.repository = additionalAmenityRepository;
        }

        public async Task<CommandResponse<AdditionalAmenity>> Handle(UpdateAdditionalAmenityCommand request, CancellationToken cancellationToken)
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

            this.repository.Modify(request);
            return this.Commit()
                       ? new CommandResponse<AdditionalAmenity> { IsSuccess = true, Message = "New Entity was added", Object = request }
                       : new CommandResponse<AdditionalAmenity> { IsSuccess = false, Message = "New Entity Not added", Object = request };
        }
    }
}