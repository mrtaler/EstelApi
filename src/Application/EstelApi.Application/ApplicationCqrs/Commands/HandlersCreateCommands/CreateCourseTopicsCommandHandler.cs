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

    public class CreateCourseTopicsCommandHandler : CommandHandler,
                                                    IRequestHandler<CreateNewCourseTopicsCommand, CommandResponse<CourseTopics>>
    {
        private readonly ICourseTopicsRepository repository;

        public CreateCourseTopicsCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            ICourseTopicsRepository courseTopicsRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseTopicsRepository;
        }

        public async Task<CommandResponse<CourseTopics>> Handle(CreateNewCourseTopicsCommand request, CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var entity = request.ProjectedAs<CourseTopics>();
            this.repository.Add(entity);

            return await this.CommitAsync()
                       ? new CommandResponse<CourseTopics> { IsSuccess = true, Message = "New Entity was added", Object = entity }
                       : new CommandResponse<CourseTopics> { IsSuccess = false, Message = "New Entity Not added", Object = entity };
        }
    }
}