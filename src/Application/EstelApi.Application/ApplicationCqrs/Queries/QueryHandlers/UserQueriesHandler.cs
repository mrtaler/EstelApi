//namespace EstelApi.Application.ApplicationCqrs.Queries.QueryHandlers
//{
//    using EstelApi.Application.ApplicationCqrs.Queries.FindByIdSpec;
//    using EstelApi.Application.ApplicationCqrs.Queries.IncludeSpec;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
//    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
//    using MediatR;
//    using System.Collections.Generic;
//    using System.Threading;
//    using System.Threading.Tasks;

//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;

//    /// <inheritdoc cref="QueryHandler" />
//    /// <summary>
//    /// The customer queries handler.
//    /// </summary>
//    public class UserQueriesHandler : QueryHandler,
//            IRequestHandler<AllEntitiesQuery<User>, IEnumerable<User>>,
//            IRequestHandler<EntityByIdQuery<User>, User>
//    {
//        /// <summary>
//        /// The customer repository.
//        /// </summary>
//        private readonly IUserRepository repository;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="CustomerQueriesHandler"/> class.
//        /// </summary>
//        /// <param name="customerRepository">
//        /// The customer repository.
//        /// </param>
//        /// <param name="uow">
//        /// The uow.
//        /// </param>
//        /// <param name="bus">
//        /// The bus.
//        /// </param>
//        /// <param name="notifications">
//        /// The notifications.
//        /// </param>
//        public UserQueriesHandler(
//            IUserRepository customerRepository,
//            IQueryableUnitOfWork uow,
//            IMediator bus,
//            INotificationHandler<DomainEvent> notifications) : base(uow, bus, notifications)
//        {
//            this.repository = customerRepository;
//        }

//        /// <summary>
//        /// The dispose.
//        /// </summary>
//        public void Dispose()
//        {
//            this.repository.Dispose();
//        }

//        /// <summary>
//        /// The handle.
//        /// </summary>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <param name="cancellationToken">
//        /// The cancellation token.
//        /// </param>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        public async Task<IEnumerable<User>> Handle(AllEntitiesQuery<User> request, CancellationToken cancellationToken)
//        {
//            var ret = this.repository.AllMatching(includes: new UserInclude());

//            return await Task.FromResult(ret);
//        }

//        /// <summary>
//        /// The handle.
//        /// </summary>
//        /// <param name="request">
//        /// The request.
//        /// </param>
//        /// <param name="cancellationToken">
//        /// The cancellation token.
//        /// </param>
//        /// <returns>
//        /// The <see cref="Task"/>.
//        /// </returns>
//        public async Task<User> Handle(EntityByIdQuery<User> request, CancellationToken cancellationToken)
//        {
//            var ret = this.repository.OneMatching(
//                filter: new FindUserById().SetId(request.Id),
//                includes: new UserInclude());

//            return await Task.FromResult(ret);
//        }
//    }
//}
