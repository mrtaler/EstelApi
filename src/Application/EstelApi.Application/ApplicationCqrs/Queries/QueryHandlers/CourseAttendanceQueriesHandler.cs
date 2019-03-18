namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class CourseAttendanceQueriesHandler : QueryHandler,
                                                  IRequestHandler<AllEntitiesQuery<CourseAttendance>, IEnumerable<CourseAttendance>>,
                                                  IRequestHandler<EntityByIdQuery<CourseAttendance>, CourseAttendance>
    {
        private ICourseAttendanceRepository repository;

        public CourseAttendanceQueriesHandler(
            IQueryableUnitOfWork uow, IMediator bus,
            INotificationHandler<DomainNotification> notifications, ICourseAttendanceRepository courseAttendanceRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseAttendanceRepository;
        }

        public async Task<IEnumerable<CourseAttendance>> Handle(AllEntitiesQuery<CourseAttendance> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.GetAll();
            return await Task.FromResult(ret);
        }

        public async Task<CourseAttendance> Handle(EntityByIdQuery<CourseAttendance> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.Get(request.Id);
            return await Task.FromResult(ret);
        }
    }
}