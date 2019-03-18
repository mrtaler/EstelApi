namespace EstelApi.Application.ApplicationCqrs.Commands.DeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Commands.CreateCommands;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class CreateCourseTopicsCommandHandler : CommandHandler,
                                                    IRequestHandler<CreateNewCourseTopicsCommand, CommandResponse<CourseTopics>>
    {
        private ICourseTopicsRepository repository;

        public CreateCourseTopicsCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            ICourseTopicsRepository courseTopicsRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseTopicsRepository;
        }

        public async Task<CommandResponse<CourseTopics>> Handle(CreateNewCourseTopicsCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<CourseTopics> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            this.repository.Add(request);

            return this.Commit()
                       ? new CommandResponse<CourseTopics> { IsSuccess = true, Message = "New Entity was added", Object = request }
                       : new CommandResponse<CourseTopics> { IsSuccess = false, Message = "New Entity Not added", Object = request };
        }
    }
}