namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.CrossCutting.Bus;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    public class DeleteCourseTopicsCommandHandler : CommandHandler,
                                                    IRequestHandler<RemoveEntityCommand<CourseTopics>, CommandResponse<CourseTopics>>
    {
        private readonly ICourseTopicsRepository courseTopicsRepository;

        public DeleteCourseTopicsCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            ICourseTopicsRepository courseTopicsRepository)
            : base(uow, bus, notifications)
        {
            this.courseTopicsRepository = courseTopicsRepository;
        }

        public async Task<CommandResponse<CourseTopics>> Handle(
            RemoveEntityCommand<CourseTopics> request,
            CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var current = this.courseTopicsRepository.OneMatching(new FindCourseTopicsById().SetId(request.Id));
            this.courseTopicsRepository.Remove(current);
            return !await this.CommitAsync()
                       ? new CommandResponse<CourseTopics>
                       {
                           IsSuccess = false,
                           Message = "Delete error",
                           Object = null
                       }
                       : new CommandResponse<CourseTopics>
                       {
                           IsSuccess = true,
                           Message = "Entity was deleted",
                           Object = current
                       };
        }

    }
}