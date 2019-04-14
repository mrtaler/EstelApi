//namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands
//{
//    using System.Threading;
//    using System.Threading.Tasks;

//    using EstelApi.Application.ApplicationCqrs.Commands.HandlersCreateCommands.CreateCommands;
//    using EstelApi.Core.Seedwork;
//    using EstelApi.Core.Seedwork.Adapter;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
//    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

//    using MediatR;

//    public class CreateAdditionalAmenityCommandHandler : CommandHandler,
//                                                         IRequestHandler<CreateNewAdditionalAmenityCommand, CommandResponse<AdditionalAmenity>>
//    {
//        private readonly IAdditionalAmenityRepository repository;

//        public CreateAdditionalAmenityCommandHandler(
//            IQueryableUnitOfWork uow,
//            IMediator bus,
//            INotificationHandler<DomainEvent> notifications,
//            IAdditionalAmenityRepository additionalAmenityRepository)
//            : base(uow, bus, notifications)
//        {
//            this.repository = additionalAmenityRepository;
//        }

//        public async Task<CommandResponse<AdditionalAmenity>> Handle(CreateNewAdditionalAmenityCommand request, CancellationToken cancellationToken)
//        {
//            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

//            var entity = request.ProjectedAs<AdditionalAmenity>();
//            this.repository.Add(entity);

//            return await this.CommitAsync()
//                       ? new CommandResponse<AdditionalAmenity> { IsSuccess = true, Message = "New Entity was added", Object = entity }
//                       : new CommandResponse<AdditionalAmenity> { IsSuccess = false, Message = "New Entity Not added", Object = entity };
//        }
//    }
//}