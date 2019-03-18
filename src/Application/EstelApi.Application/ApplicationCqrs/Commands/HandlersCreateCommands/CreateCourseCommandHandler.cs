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

    public class CreateCourseCommandHandler : CommandHandler,
                                              IRequestHandler<CreateNewCourseCommand, CommandResponse<Course>>
    {
        private ICourseRepository repository;

        public CreateCourseCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            ICourseRepository courseRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseRepository;
        }

        public async Task<CommandResponse<Course>> Handle(CreateNewCourseCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "message is null"),
                    cancellationToken);
                return new CommandResponse<Course> { IsSuccess = false, Message = "message is null", Object = null };

                // throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
            }

            this.repository.Add(request);

            return this.Commit()
                       ? new CommandResponse<Course> { IsSuccess = true, Message = "New Entity was added", Object = request }
                       : new CommandResponse<Course> { IsSuccess = false, Message = "New Entity Not added", Object = request };
        }
    }
}