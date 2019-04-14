namespace EstelApi.Application.ApplicationCqrs.Commands.HandlersDeleteCommands
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

    /// <inheritdoc cref="CommandHandler" />
    public class DeleteCourseAttendanceCommandHandler : CommandHandler,
                                                        IRequestHandler<RemoveEntityCommand<CourseAttendance>, CommandResponse<CourseAttendance>>
    {
        private readonly ICourseAttendanceRepository courseAttendanceRepository;

        public DeleteCourseAttendanceCommandHandler(
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainEvent> notifications,
            ICourseAttendanceRepository courseAttendanceRepository)
            : base(uow, bus, notifications)
        {
            this.courseAttendanceRepository = courseAttendanceRepository;
        }

        public async Task<CommandResponse<CourseAttendance>> Handle(
            RemoveEntityCommand<CourseAttendance> request,
            CancellationToken cancellationToken)
        {
            Contract.ThrowIfNull(request, request.GetType().Name, this.Bus);

            var current = this.courseAttendanceRepository.OneMatching(new FindCourseAttendanceById().SetId(request.Id));
            this.courseAttendanceRepository.Remove(current);
            return !await this.CommitAsync()
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