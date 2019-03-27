namespace EstelApi.Application.ApplicationCqrs.Commands.Course
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
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
            INotificationHandler<DomainNotification> notifications,
            ICourseRepository courseRepository)
            : base(uow, bus, notifications)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<CommandResponse<Course>> Handle(
          RemoveEntityCommand<Course> request,
          CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<Course>
                {
                    IsSuccess = false,
                    Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };
            }

            var current = this.courseRepository.OneMatching(new FindCourseById().SetId(request.Id));
            this.courseRepository.Remove(current);
            return !await this.Commit()
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