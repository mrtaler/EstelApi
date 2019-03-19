namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
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

    /// <summary>
    /// The delete course type command handler.
    /// </summary>
    public class DeleteCourseTypeCommandHandler : CommandHandler,
                                                  IRequestHandler<RemoveEntityCommand<CourseType>, CommandResponse<CourseType>>
    {
        private ICourseTypeRepository courseTypeRepository;

        public DeleteCourseTypeCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            ICourseTypeRepository courseTypeRepository)
            : base(uow, bus, notifications)
        {
            this.courseTypeRepository = courseTypeRepository;
        }

        public async Task<CommandResponse<CourseType>> Handle(
            RemoveEntityCommand<CourseType> request,
            CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<CourseType>
                {
                    IsSuccess = false,
                    Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };
            }

            var current = this.courseTypeRepository.OneMatching(new FindCourseTypeById().SetId(request.Id));
            this.courseTypeRepository.Remove(current);
            return !this.Commit()
                       ? new CommandResponse<CourseType>
                       {
                           IsSuccess = false,
                           Message = "Delete error",
                           Object = null
                       }
                       : new CommandResponse<CourseType>
                       {
                           IsSuccess = true,
                           Message = "Entity was deleted",
                           Object = current
                       };

            /* await this.bus.Publish(
                 new CustomerRemovedEvent(
                     current.Id),
                 cancellationToken);*/
        }
    }
}