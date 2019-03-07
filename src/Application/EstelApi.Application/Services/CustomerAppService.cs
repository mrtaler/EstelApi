using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands;
using EstelApi.Application.Cqrs.Queries.Queries.CustomerQueries;
using EstelApi.Application.EventSourcedNormalizers;
using EstelApi.Application.Interfaces;
using EstelApi.Application.ViewModels.Customer;
using EstelApi.Core.Seedwork.Adapter;
using EstelApi.Core.Seedwork.CoreCqrs.Events;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

using MediatR;

namespace EstelApi.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;
        private readonly IEventStoreRepository eventStoreRepository;
        private readonly IMediator bus;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediator bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<CustomerViewModelApp> GetAll()
        {
            var result = this.bus.Send(new AllCustomersQuery()).Result;

            var ret = result.ProjectedAsCollection<CustomerViewModelApp>();

            return
                ret; // _customerRepository.GetAll().AsQueryable().ProjectTo<CustomerViewModelApp>(_mapper.ConfigurationProvider);
        }

        public CustomerViewModelApp GetById(Guid id)
        {
            return this.mapper.Map<CustomerViewModelApp>(this.customerRepository.GetById(id));
        }

        public async Task<CustomerViewModelApp> Register(CreateCustomerViewModel customerViewModel)
        {
            var registerCommand = customerViewModel.ProjectedAs<RegisterNewCustomerCommand>();// _mapper.Map<>(customerViewModel);
            var result = await this.bus.Send(registerCommand);
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
            var updateCommand = customerViewModel.ProjectedAs<UpdateCustomerCommand>();// _mapper.Map<>(customerViewModel);
            this.bus.Send(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            this.bus.Send(removeCommand);
        }

        public async Task<IList<CustomerHistoryData>> GetAllHistory(Guid id)
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(await this.eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
