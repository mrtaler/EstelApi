namespace EstelApi.Application.ApplicationCqrs.Commands.Course.UpdateCourse
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.CrossCutting.Bus;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class UpdateCourseCommandHandler : CommandHandler,
                                              IRequestHandler<UpdateCourseCommand, CommandResponse<Course>>
    {
        private readonly ICourseRepository repository;

        public UpdateCourseCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            ICourseRepository courseRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseRepository;
        }

        public async Task<CommandResponse<Course>> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var entity = request.ProjectedAs<Course>();
            this.repository.Modify(entity);
            return await this.CommitAsync()
                       ? new CommandResponse<Course> { IsSuccess = true, Message = "New Entity was added", Object = entity }
                       : new CommandResponse<Course> { IsSuccess = false, Message = "New Entity Not added", Object = entity };
        }
    }
}