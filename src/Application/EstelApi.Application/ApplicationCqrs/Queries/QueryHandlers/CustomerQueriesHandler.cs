namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using EstelApi.Application.ApplicationCqrs.Base;
    // using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <inheritdoc cref="QueryHandler" />
    /// <summary>
    /// The customer queries handler.
    /// </summary>
    public class CustomerQueriesHandler : QueryHandler,
            IRequestHandler<AllEntitiesQuery<Customer>, IEnumerable<Customer>>,
            IRequestHandler<EntityByIdQuery<Customer>, Customer>
    {
        /// <summary>
        /// The customer repository.
        /// </summary>
        private readonly ICustomerRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerQueriesHandler"/> class.
        /// </summary>
        /// <param name="customerRepository">
        /// The customer repository.
        /// </param>
        /// <param name="uow">
        /// The uow.
        /// </param>
        /// <param name="bus">
        /// The bus.
        /// </param>
        /// <param name="notifications">
        /// The notifications.
        /// </param>
        public CustomerQueriesHandler(
            ICustomerRepository customerRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.repository = customerRepository;
            this.repository.SetInclude(new List<Func<IQueryable<Customer>, IQueryable<Customer>>>
                                          {
                                              p=>p.Include(x=>x.CourseAttendances)
                                          });
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.repository.Dispose();
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IEnumerable<Customer>> Handle(AllEntitiesQuery<Customer> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.GetAll();

            return await Task.FromResult(ret);
            // return await Task.FromResult(ret.ProjectedAsCollection<Customer>());
        }

        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation token.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Customer> Handle(EntityByIdQuery<Customer> request, CancellationToken cancellationToken)
        {
            var ret = this.repository.Get(request.Id);
            return await Task.FromResult(ret);
            // return await Task.FromResult(ret.ProjectedAs<Customer>());
        }
    }
}
