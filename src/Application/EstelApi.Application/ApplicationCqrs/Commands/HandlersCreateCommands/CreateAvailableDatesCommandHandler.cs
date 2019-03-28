namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.CrossCutting.Bus;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class CreateAvailableDatesCommandHandler : CommandHandler,
                                        IRequestHandler<CreateNewAvailableDatesCommand, CommandResponse<AvailableDates>>
    {
        private readonly IAvailableDatesRepository repository;

        public CreateAvailableDatesCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            IAvailableDatesRepository availableDatesRepository)
            : base(uow, bus, notifications)
        {
            this.repository = availableDatesRepository;
        }

        public async Task<CommandResponse<AvailableDates>> Handle(CreateNewAvailableDatesCommand request, CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var entity = request.ProjectedAs<AvailableDates>();
            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? new CommandResponse<AvailableDates> { IsSuccess = true, Message = "New Entity was added", Object = entity }
                       : new CommandResponse<AvailableDates> { IsSuccess = false, Message = "New Entity Not added", Object = entity };
        }
    }
}
