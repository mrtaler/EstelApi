namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
{
    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCourseTopicsCommandHandler : CommandHandler,
                                                    IRequestHandler<RemoveEntityCommand<CourseTopics>, CommandResponse<CourseTopics>>
    {
        private ICourseTopicsRepository courseTopicsRepository;

        public DeleteCourseTopicsCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            ICourseTopicsRepository courseTopicsRepository)
            : base(uow, bus, notifications)
        {
            this.courseTopicsRepository = courseTopicsRepository;
        }

        public async Task<CommandResponse<CourseTopics>> Handle(
            RemoveEntityCommand<CourseTopics> request,
            CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<CourseTopics>
                {
                    IsSuccess = false,
                    Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };
            }

            var current = this.courseTopicsRepository.OneMatching(new FindCourseTopicsById().SetId(request.Id));
            this.courseTopicsRepository.Remove(current);
            return !this.Commit()
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