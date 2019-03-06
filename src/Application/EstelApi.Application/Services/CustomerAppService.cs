using AutoMapper;
using EstelApi.Application.EventSourcedNormalizers;
using EstelApi.Application.Interfaces;
using EstelApi.Application.ViewModels.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands;
using EstelApi.Core.Seedwork.CoreCqrs.Events;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Application.Cqrs.Queries.Queries.CustomerQueries;
using EstelApi.Core.Seedwork.Adapter;

namespace EstelApi.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediator _bus;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediator bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<CustomerViewModelApp> GetAll()
        {
            var result = _bus.Send(new AllCustomersQuery()).Result;

            var ret = result.ProjectedAsCollection<CustomerViewModelApp>();

            return
                ret; //_customerRepository.GetAll().AsQueryable().ProjectTo<CustomerViewModelApp>(_mapper.ConfigurationProvider);
        }

        public CustomerViewModelApp GetById(Guid id)
        {
            return _mapper.Map<CustomerViewModelApp>(_customerRepository.GetById(id));
        }

        public async Task<CustomerViewModelApp> Register(CreateCustomerViewModel customerViewModel)
        {
            var registerCommand = customerViewModel.ProjectedAs<RegisterNewCustomerCommand>();// _mapper.Map<>(customerViewModel);
            var result = await _bus.Send(registerCommand);
            if ( result .IsSuccess)
            {
                var retVal = new CustomerViewModelApp
                {
                    BirthDate = result.Object.BirthDate,
                    Email = result.Object.Email,
                    Id = result.Object.Id,
                    Name = result.Object.Name
                };

                return retVal;
            }
            return new CustomerViewModelApp();
        }


        public void Update(UpdateCustomerViewModel customerViewModel)
        {
            var updateCommand = customerViewModel.ProjectedAs<UpdateCustomerCommand>();//_mapper.Map<>(customerViewModel);
            _bus.Send(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            _bus.Send(removeCommand);
        }

        public IList<CustomerHistoryData> GetAllHistory(Guid id)
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
