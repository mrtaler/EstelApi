namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Core.Seedwork;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    public class UpdateAdditionalAmenityCommandHandler : CommandHandler,
                                                         IRequestHandler<UpdateAdditionalAmenityCommand, CommandResponse<AdditionalAmenity>>
    {
        private readonly IAdditionalAmenityRepository repository;

        public UpdateAdditionalAmenityCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            IAdditionalAmenityRepository additionalAmenityRepository)
            : base(uow, bus, notifications)
        {
            this.repository = additionalAmenityRepository;
        }

        public async Task<CommandResponse<AdditionalAmenity>> Handle(UpdateAdditionalAmenityCommand request, CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);


            var updateAdditionalAmenity = request.ProjectedAs<AdditionalAmenity>();
            this.repository.Modify(updateAdditionalAmenity);
       
            return await this.CommitAsync()
                       ? new CommandResponse<AdditionalAmenity> { IsSuccess = true, Message = "New Entity was added", Object = updateAdditionalAmenity }
                       : new CommandResponse<AdditionalAmenity> { IsSuccess = false, Message = "New Entity Not added", Object = updateAdditionalAmenity };
        }
    }
}