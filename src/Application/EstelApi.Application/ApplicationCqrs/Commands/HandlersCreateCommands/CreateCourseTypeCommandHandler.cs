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

//    /// <summary>
//    /// The delete course type command handler.
//    /// </summary>
//    public class CreateCourseTypeCommandHandler : CommandHandler,
//                                                  IRequestHandler<CreateNewCourseTypeCommand, CommandResponse<CourseType>>
//    {
//        private readonly ICourseTypeRepository repository;

//        public CreateCourseTypeCommandHandler(
//            IQueryableUnitOfWork uow,
//            IMediator bus,
//            INotificationHandler<DomainEvent> notifications,
//            ICourseTypeRepository courseTypeRepository)
//            : base(uow, bus, notifications)
//        {
//            this.repository = courseTypeRepository;
//        }

//        public async Task<CommandResponse<CourseType>> Handle(CreateNewCourseTypeCommand request, CancellationToken cancellationToken)
//        {
//            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

//            var entity = request.ProjectedAs<CourseType>();
//            this.repository.Add(entity);

//            return await this.CommitAsync()
//                       ? new CommandResponse<CourseType> { IsSuccess = true, Message = "New Entity was added", Object = entity }
//                       : new CommandResponse<CourseType> { IsSuccess = false, Message = "New Entity Not added", Object = entity };
//        }
//    }
//}