namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.HandlersUpdateCommands.UpdateCommands;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="CommandHandler" />
    public class UpdateCourseTopicsCommandHandler : CommandHandler,
                                                    IRequestHandler<UpdateCourseTopicsCommand, CommandResponse<CourseTopics>>
    {
        private readonly ICourseTopicsRepository repository;

        public UpdateCourseTopicsCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            ICourseTopicsRepository courseTopicsRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseTopicsRepository;
        }

        public async Task<CommandResponse<CourseTopics>> Handle(UpdateCourseTopicsCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.Bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<CourseTopics> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            var updateCourseTopics = request.ProjectedAs<CourseTopics>();
            this.repository.Modify(updateCourseTopics);

            return await this.Commit()
                       ? new CommandResponse<CourseTopics> { IsSuccess = true, Message = "New Entity was added", Object = updateCourseTopics }
                       : new CommandResponse<CourseTopics> { IsSuccess = false, Message = "New Entity Not added", Object = updateCourseTopics };
        }
    }
}