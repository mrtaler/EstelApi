//namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
//{
//    using System.Collections.Generic;
//    using System.Threading;
//    using System.Threading.Tasks;

//    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
//    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
//    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

//    using MediatR;

//    public class CourseTopicsQueriesHandler : QueryHandler,
//                                              IRequestHandler<AllEntitiesQuery<CourseTopics>, IEnumerable<CourseTopics>>,
//                                              IRequestHandler<EntityByIdQuery<CourseTopics>, CourseTopics>
//    {
//        private ICourseTopicsRepository repository;

//        public CourseTopicsQueriesHandler(
//            IQueryableUnitOfWork uow, IMediator bus,
//            INotificationHandler<DomainEvent> notifications, ICourseTopicsRepository courseTopicsRepository)
//            : base(uow, bus, notifications)
//        {
//            this.repository = courseTopicsRepository;
//        }

//        public async Task<IEnumerable<CourseTopics>> Handle(AllEntitiesQuery<CourseTopics> request, CancellationToken cancellationToken)
//        {
//            var ret = this.repository.AllMatching(includes:new CourseTopicsInclude());
//            return await Task.FromResult(ret);
//        }

//        public async Task<CourseTopics> Handle(EntityByIdQuery<CourseTopics> request, CancellationToken cancellationToken)
//        {
//            var ret = this.repository.OneMatching(
//                filter: new FindCourseTopicsById().SetId(request.Id),
//                includes: new CourseTopicsInclude());

//            return await Task.FromResult(ret);
//        }
//    }
//}