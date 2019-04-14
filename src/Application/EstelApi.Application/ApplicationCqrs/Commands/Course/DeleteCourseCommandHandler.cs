namespace EstelApi.Application.ApplicationCqrs.Commands.Course
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

    public class DeleteCourseCommandHandler : CommandHandler,
                                              IRequestHandler<RemoveEntityCommand<Course>, CommandResponse<Course>>
    {
        private readonly ICourseRepository courseRepository;

        public DeleteCourseCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            ICourseRepository courseRepository)
            : base(uow, bus, notifications)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<CommandResponse<Course>> Handle(
          RemoveEntityCommand<Course> request,
          CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var current = this.courseRepository.OneMatching(new FindCourseById().SetId(request.Id));
            this.courseRepository.Remove(current);
            return !await this.CommitAsync().ConfigureAwait(false)
                       ? new CommandResponse<Course> { IsSuccess = false, Message = "Delete error", Object = null }
                       : new CommandResponse<Course>
                       {
                           IsSuccess = true,
                           Message = "Entity was deleted",
                           Object = current
                       };
        }
    }
}