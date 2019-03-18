﻿namespace EstelApi.Application.ApplicationCqrs.Commands.DeleteCommands
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

    public class UpdateAvailableDatesCommandHandler : CommandHandler,
                                        IRequestHandler<UpdateAvailableDatesCommand, CommandResponse<AvailableDates>>
    {
        private IAvailableDatesRepository repository;

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

            this.repository.Modify(request);
            return this.Commit()
                       ? new CommandResponse<AvailableDates> { IsSuccess = true, Message = "New Entity was added", Object = request }
                       : new CommandResponse<AvailableDates> { IsSuccess = false, Message = "New Entity Not added", Object = request };
        }
    }
}
