namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    using Microsoft.EntityFrameworkCore;

    public class CourseQueriesHandler : QueryHandler,
                                        IRequestHandler<AllEntitiesQuery<Course>, IEnumerable<Course>>,
                                        IRequestHandler<EntityByIdQuery<Course>, Course>
    {
        private ICourseRepository repository;

        public CourseQueriesHandler(
            IQueryableUnitOfWork uow, IMediator bus,
            INotificationHandler<DomainNotification> notifications, ICourseRepository courseRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseRepository;
            this.repository.SetInclude(new List<Func<IQueryable<Course>, IQueryable<Course>>>
                                           {
                                               x=>x.Include(p=>p.CourseType),
                                               x=>x.Include(p=>p.CourseAttendances),
                                               x=>x.Include(p=>p.CourseTopics),
                                               x=>x.Include(p=>p.AdditionalAmenityCourses),
                                               x=>x.Include(p=>p.AvailableDates),

                                           });
        }

        public async Task<IEnumerable<Course>> Handle(AllEntitiesQuery<Course> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.GetAll();
            return await Task.FromResult(ret);
        }

        public async Task<Course> Handle(EntityByIdQuery<Course> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.Get(request.Id);
            return await Task.FromResult(ret);
        }
    }
}