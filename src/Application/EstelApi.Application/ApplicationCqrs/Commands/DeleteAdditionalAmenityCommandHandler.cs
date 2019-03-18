namespace EstelApi.Application.ApplicationCqrs.Commands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class DeleteAdditionalAmenityCommandHandler : CommandHandler,
                                                         IRequestHandler<RemoveEntityCommand<AdditionalAmenity>, CommandResponse<AdditionalAmenity>>
    {
        private IAdditionalAmenityRepository additionalAmenityRepository;

        public DeleteAdditionalAmenityCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            IAdditionalAmenityRepository additionalAmenityRepository)
            : base(uow, bus, notifications)
        {
            this.additionalAmenityRepository = additionalAmenityRepository;
        }

     
        public async Task<CommandResponse<AdditionalAmenity>> Handle(
            RemoveEntityCommand<AdditionalAmenity> request,
            CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<AdditionalAmenity>
                           {
                               IsSuccess = false,
                               Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                               Object = null
                           };
            }

            var current = this.additionalAmenityRepository.Get(request.Id);
            this.additionalAmenityRepository.Remove(current);
            return !this.Commit()
                       ? new CommandResponse<AdditionalAmenity>
                             {
                                 IsSuccess = false,
                                 Message = "Delete error",
                                 Object = null
                             }
                       : new CommandResponse<AdditionalAmenity>
                             {
                                 IsSuccess = true,
                                 Message = "Entity was deleted",
                                 Object = current
                             };
        }
    }
}