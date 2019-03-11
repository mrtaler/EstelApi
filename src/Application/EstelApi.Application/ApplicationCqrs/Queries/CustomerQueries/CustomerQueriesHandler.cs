namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Application.Dto;
    using EstelApi.Core.Seedwork.Adapter;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    using MediatR;

    /// <inheritdoc cref="QueryHandler" />
    /// <summary>
    /// The customer queries handler.
    /// </summary>
    public class CustomerQueriesHandler : QueryHandler,
            IRequestHandler<AllCustomersQuery, IEnumerable<CustomerDto>>,
            IRequestHandler<CustomerByIdQuery, CustomerDto>
    {
        /// <summary>
        /// The customer repository.
        /// </summary>
        private readonly ICustomerRepository customerRepository;

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
           this.customerRepository = customerRepository;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.customerRepository.Dispose();
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
        public async Task<IEnumerable<CustomerDto>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        {
            var ret = this.customerRepository.GetAll();
            return await Task.FromResult(ret.ProjectedAsCollection<CustomerDto>());
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
        public async Task<CustomerDto> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var ret = this.customerRepository.Get(request.Id);
            return await Task.FromResult(ret.ProjectedAs<CustomerDto>());
        }
    }
}
