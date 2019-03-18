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