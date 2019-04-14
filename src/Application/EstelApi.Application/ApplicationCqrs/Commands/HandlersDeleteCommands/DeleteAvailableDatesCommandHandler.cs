namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork;
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
            INotificationHandler<DomainEvent> notifications,
            IAvailableDatesRepository availableDatesRepository)
            : base(uow, bus, notifications)
        {
            this.availableDatesRepository = availableDatesRepository;
        }

        public async Task<CommandResponse<AvailableDates>> Handle(
            RemoveEntityCommand<AvailableDates> request,
            CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var current = this.availableDatesRepository.OneMatching(new FindAvailableDatesById().SetId(request.Id));
            this.availableDatesRepository.Remove(current);
            return !await this.CommitAsync()
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
