namespace EstelApi.Application.ApplicationCqrs.Commands.DeleteCommands
{
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class DeleteCourseAttendanceCommandHandler : CommandHandler,
                                                        IRequestHandler<RemoveEntityCommand<CourseAttendance>, CommandResponse<CourseAttendance>>
    {
        private ICourseAttendanceRepository courseAttendanceRepository;

        public DeleteCourseAttendanceCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications,
            ICourseAttendanceRepository courseAttendanceRepository)
            : base(uow, bus, notifications)
        {
            this.courseAttendanceRepository = courseAttendanceRepository;
        }

        public async Task<CommandResponse<CourseAttendance>> Handle(
            RemoveEntityCommand<CourseAttendance> request,
            CancellationToken cancellationToken)
        {
            if (request == null || request.Id == 0)
            {
                await this.bus.Publish(
                    new DomainNotification(
                        request.GetType().Name,
                        "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)"),
                    cancellationToken);
                return new CommandResponse<CourseAttendance>
                {
                    IsSuccess = false,
                    Message =
                                   "_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)",
                    Object = null
                };
            }

            var current = this.courseAttendanceRepository.Get(request.Id);
            this.courseAttendanceRepository.Remove(current);
            return !this.Commit()
                       ? new CommandResponse<CourseAttendance>
                       {
                           IsSuccess = false,
                           Message = "Delete error",
                           Object = null
                       }
                       : new CommandResponse<CourseAttendance>
                       {
                           IsSuccess = true,
                           Message = "Entity was deleted",
                           Object = current
                       };
        }

    }
}