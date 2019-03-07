namespace EstelApi.Application.ApplicationCqrs.Queries.CustomerQueries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using EstelApi.Application.ApplicationCqrs.Base;
    using EstelApi.Core.Seedwork.CoreCqrs.Notifications;

    using MediatR;

    public class CustomerQueriesHandler : QueryHandler,
            IRequestHandler<AllCustomersQuery, IEnumerable<Customer>>,
            IRequestHandler<CustomerByIdQuery, Customer>// ,
                                                           // IRequestHandler<UpdateCustomerCommand, bool>,
    {
        // IRequestHandler<RemoveCustomerCommand, bool>
        private readonly ICustomerRepository customerRepository;
        private readonly IMediator bus;

        public CustomerQueriesHandler(ICustomerRepository customerRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.customerRepository = customerRepository;
            this.bus = bus;
        }

        public void Dispose()
        {
            this.customerRepository.Dispose();
        }

        public async Task<IEnumerable<Customer>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        {
            var ret = this.customerRepository.GetAll();
            return await Task.FromResult(ret);
        }

        public Task<Customer> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
