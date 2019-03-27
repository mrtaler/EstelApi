namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    public class DeleteAvailableDatesCommandHandler : CommandHandler,
                                        IRequestHandler<RemoveEntityCommand<AvailableDates>, CommandResponse<AvailableDates>>
    {
        private readonly IAvailableDatesRepository availableDatesRepository;

        public DeleteAvailableDatesCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            IAvailableDatesRepository availableDatesRepository)
            : base(uow, bus, notifications)
        {
            this.availableDatesRepository = availableDatesRepository;
        }

        public async Task<CommandResponse<AvailableDates>> Handle(
            RemoveEntityCommand<AvailableDates> request,
            CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
            {
                await this.Bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<AvailableDates>
                {
                    IsSuccess = false,
                    Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };
            }

            var current = this.availableDatesRepository.OneMatching(new FindAvailableDatesById().SetId(request.Id));
            this.availableDatesRepository.Remove(current);
            return !await this.Commit()
                       ? new CommandResponse<AvailableDates>
                       {
                           IsSuccess = false,
                           Message = "Delete error",
                           Object = null
                       }
                       : new CommandResponse<AvailableDates>
                       {
                           IsSuccess = true,
                           Message = "Entity was deleted",
                           Object = current
                       };
        }
    }
}
