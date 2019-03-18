namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Done;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    public class CourseTypeQueriesHandler : QueryHandler,
                                            IRequestHandler<AllEntitiesQuery<CourseType>, IEnumerable<CourseType>>,
                                            IRequestHandler<EntityByIdQuery<CourseType>, CourseType>
    {
        private ICourseTypeRepository repository;

        public CourseTypeQueriesHandler(
            IQueryableUnitOfWork uow, IMediator bus,
            INotificationHandler<DomainNotification> notifications, ICourseTypeRepository courseTypeRepository)
            : base(uow, bus, notifications)
        {
            this.repository = courseTypeRepository;
        }

        public async Task<IEnumerable<CourseType>> Handle(AllEntitiesQuery<CourseType> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.GetAll();
            return await Task.FromResult(ret);
        }

        public async Task<CourseType> Handle(EntityByIdQuery<CourseType> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.Get(request.Id);
            return await Task.FromResult(ret);
        }
    }
}