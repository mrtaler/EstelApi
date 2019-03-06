using EstelApi.Core.Seedwork.Adapter;
using EstelApi.Domain.Cqrs.Base;
using EstelApi.Domain.Cqrs.Dto;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EstelApi.Core.Seedwork.CoreCqrs.Notifications;

namespace EstelApi.Domain.Cqrs.Queries.CustomerQueries
{
    public class CustomerQueriesHandler : CommandHandler,
            IRequestHandler<AllCustomersQuery, IEnumerable<CustomerDto>>,
            IRequestHandler<CustomerByIdQuery, CustomerDto>//,
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

        public async Task<IEnumerable<CustomerDto>> Handle(AllCustomersQuery request, CancellationToken cancellationToken)
        {
            var ret = _customerRepository.GetAll().ProjectedAsCollection<CustomerDto>();
            return await Task.FromResult(ret);
        }

        public Task<CustomerDto> Handle(CustomerByIdQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
