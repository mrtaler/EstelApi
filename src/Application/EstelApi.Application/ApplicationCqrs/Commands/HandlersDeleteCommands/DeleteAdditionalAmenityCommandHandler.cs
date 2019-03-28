namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.CrossCutting.Bus;
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
            INotificationHandler<DomainEvent> notifications,
            IAdditionalAmenityRepository additionalAmenityRepository)
            : base(uow, bus, notifications)
        {
            this.additionalAmenityRepository = additionalAmenityRepository;
        }


        public async Task<CommandResponse<AdditionalAmenity>> Handle(
            RemoveEntityCommand<AdditionalAmenity> request,
            CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var current = this.additionalAmenityRepository.OneMatching(new FindAdditionalAmenityById().SetId(request.Id));
            this.additionalAmenityRepository.Remove(current);
            return !await this.CommitAsync()
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