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

    public class CourseTopicsQueriesHandler : QueryHandler,
                                              IRequestHandler<AllEntitiesQuery<CourseTopics>, IEnumerable<CourseTopics>>,
                                              IRequestHandler<EntityByIdQuery<CourseTopics>, CourseTopics>
    {
        private ICourseTopicsRepository repository;

        public CourseTopicsQueriesHandler(
            IQueryableUnitOfWork uow, IMediator bus,
            INotificationHandler<DomainNotification> notifications, ICourseTopicsRepository courseTopicsRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseTopicsRepository;
        }

        public async Task<IEnumerable<CourseTopics>> Handle(AllEntitiesQuery<CourseTopics> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.GetAll();
            return await Task.FromResult(ret);
        }

        public async Task<CourseTopics> Handle(EntityByIdQuery<CourseTopics> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.Get(request.Id);
            return await Task.FromResult(ret);
        }
    }
}