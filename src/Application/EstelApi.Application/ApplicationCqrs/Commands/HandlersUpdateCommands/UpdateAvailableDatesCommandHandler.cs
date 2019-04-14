//namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands
//{
//    using System.Threading;
//    using System.Threading.Tasks;

//    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
//    using EstelApi.Core.Seedwork;
//    using EstelApi.Core.Seedwork.Adapter;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
//    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

//    using MediatR;

//    /// <inheritdoc cref="CommandHandler" />
//    public class UpdateAvailableDatesCommandHandler : CommandHandler,
//                                        IRequestHandler<UpdateAvailableDatesCommand, CommandResponse<AvailableDates>>
//    {
//        private readonly IAvailableDatesRepository repository;

//        public UpdateAvailableDatesCommandHandler(
//            IQueryableUnitOfWork uow,
//            IMediator bus,
//            INotificationHandler<DomainEvent> notifications,
//            IAvailableDatesRepository availableDatesRepository)
//            : base(uow, bus, notifications)
//        {
//            this.repository = availableDatesRepository;
//        }

//        public async Task<CommandResponse<AvailableDates>> Handle(UpdateAvailableDatesCommand request, CancellationToken cancellationToken)
//        {
//            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

//            var updateAvailableDates = request.ProjectedAs<AvailableDates>();
//            this.repository.Modify(updateAvailableDates);

//            return await this.CommitAsync()
//                       ? new CommandResponse<AvailableDates> { IsSuccess = true, Message = "New Entity was added", Object = updateAvailableDates }
//                       : new CommandResponse<AvailableDates> { IsSuccess = false, Message = "New Entity Not added", Object = updateAvailableDates };
//        }
//    }
//}
