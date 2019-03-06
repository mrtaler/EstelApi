using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EstelApi.Application.Cqrs.Queries.Base;
using EstelApi.Core.Seedwork.CoreCqrs.Notifications;
using EstelApi.Core.Seedwork.CoreEntities;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using MediatR;

namespace EstelApi.Application.Cqrs.Queries.Queries.CustomerQueries
{
    public class CustomerQueriesHandler : QueryHandler,
            IRequestHandler<AllCustomersQuery, IEnumerable<Customer>>,
            IRequestHandler<CustomerByIdQuery, Customer>//,
                                                           // IRequestHandler<UpdateCustomerCommand, bool>,
                                                           // IRequestHandler<RemoveCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMediator _bus;

        public CustomerQueriesHandler(ICustomerRepository customerRepository,
            IQueryableUnitOfWork uow,
            IMediator bus,
            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _customerRepository = customerRepository;
            _bus = bus;
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }

        public async Task<IEnumerable<Customer>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        {
            var ret = _customerRepository.GetAll();
            return await Task.FromResult(ret);
        }

        public Task<Customer> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
