namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    using Microsoft.EntityFrameworkCore;

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
            var ret = this.repository.AllMatching(includes:new CourseAttendanceInclude());
            return await Task.FromResult(ret);
        }

        public async Task<CourseAttendance> Handle(EntityByIdQuery<CourseAttendance> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.OneMatching(
                filter: new FindCourseAttendanceById().SetId(request.Id),
                includes: new CourseAttendanceInclude());

            return await Task.FromResult(ret);
        }
    }
}