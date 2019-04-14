//namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
//{
//    using System.Threading;
//    using System.Threading.Tasks;

//    using EstelApi.Application.ApplicationCqrs.Base;
//    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
//    using EstelApi.Core.Seedwork;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
//    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

//    using MediatR;

//    /// <inheritdoc cref="CommandHandler" />
//    public class DeleteWorkerCommandHandler : CommandHandler,
//                                              IRequestHandler<RemoveEntityCommand<Worker>, CommandResponse<Worker>>
//    {
//        private readonly IWorkerRepository workerRepository;

//        public DeleteWorkerCommandHandler(
//            IQueryableUnitOfWork uow,
//            IMediator bus,
//            INotificationHandler<DomainEvent> notifications,
//            IWorkerRepository workerRepository)
//            : base(uow, bus, notifications)
//        {
//            this.workerRepository = workerRepository;
//        }

//        public async Task<CommandResponse<Worker>> Handle(
//            RemoveEntityCommand<Worker> request,
//            CancellationToken cancellationToken)
//        {
//            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

//            var current = this.workerRepository.OneMatching(new FindWorkerById().SetId(request.Id));
//            this.workerRepository.Remove(current);
//            return !await this.CommitAsync().ConfigureAwait(false)
//                       ? new CommandResponse<Worker> { IsSuccess = false, Message = "Delete error", Object = null }
//                       : new CommandResponse<Worker>
//                             {
//                                 IsSuccess = true,
//                                 Message = "Entity was deleted",
//                                 Object = current
//                             };
//        }
//    }
//}