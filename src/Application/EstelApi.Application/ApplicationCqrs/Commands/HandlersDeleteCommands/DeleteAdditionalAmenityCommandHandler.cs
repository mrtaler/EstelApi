﻿namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
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
    public class DeleteAdditionalAmenityCommandHandler : CommandHandler,
                                                         IRequestHandler<RemoveEntityCommand<AdditionalAmenity>, CommandResponse<AdditionalAmenity>>
    {
        private readonly IAdditionalAmenityRepository additionalAmenityRepository;

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
                await this.Bus.Publish(
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

            var current = this.additionalAmenityRepository.OneMatching(new FindAdditionalAmenityById().SetId(request.Id));
            this.additionalAmenityRepository.Remove(current);
            return !await this.Commit()
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