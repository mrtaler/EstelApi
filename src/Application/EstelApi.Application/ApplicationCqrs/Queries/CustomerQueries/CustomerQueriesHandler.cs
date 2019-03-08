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

    public class CustomerQueriesHandler : QueryHandler,
            IRequestHandler<AllCustomersQuery, IEnumerable<CustomerDTO>>,
            IRequestHandler<CustomerByIdQuery, CustomerDTO>// ,
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

        public async Task<IEnumerable<CustomerDTO>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        {
            var ret = this.customerRepository.GetAll();
            return await Task.FromResult(ret.ProjectedAsCollection<CustomerDTO>());
        }

        public Task<CustomerDTO> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
